using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Movie_Theater
{
    public partial class ManagerPortal : Form
    {
        private const string DbServerHost = "localhost";
        //private const string DbUsername = "postgres";
        private const string DbUsername = "username";
        //private const string DbUuserPassword = "yvnft9k";
        //private const string DbUuserPassword = "1013";
        private const string DbUuserPassword = "password";
        //private const string DbName = "movietheaterdb";
        private const string DbName = "movietheater_db";

        NpgsqlConnection dbConnection;

        List<Movie> foundMovieList = new List<Movie>();
        List<Genre> foundGenreList = new List<Genre>();
        List<ScreeningRoom> foundScreeningRoomList = new List<ScreeningRoom>();
        List<Showtime> foundShowtimeList = new List<Showtime>();
        List<E_Ticket> foundETicketList = new List<E_Ticket>();
        List<UserAccount> foundUserAccountList = new List<UserAccount>();
        public ManagerPortal()
        {
            InitializeComponent();

            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

            DisableMovieTB();
            GetMoviesFromDB();
            //GetGenresFromDB();
            GetScreeningRoomsFromDB();
            GetShowtimesFromDB();
            GetUserAccountsFromDB();
        }

        private void SetDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            string connectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(connectionString);
        }

        private NpgsqlConnection CreateDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);

            return dbConnection;
        }

        private void DisplayMovies()
        {
            // Loops through foundMovieList
            for (int i = 0; i < foundMovieList.Count; i++)
            {
                // Adds the foundMovieList to the movieListBox
                movieListBox.Items.Add(foundMovieList[i].Title);
            }
        }

        private void DisplayScreeningRooms()
        {
            // Loops through genreList
            for (int i = 0; i < foundScreeningRoomList.Count; i++)
            {
                // Adds the foundGenreList to the screeningRoomListBox
                screeningRoomListBox.Items.Add(foundScreeningRoomList[i].Code);
            }
        }

        private void DisplayShowtimes()
        {
            // Loops through foundShowTimeList
            for (int i = 0; i < foundShowtimeList.Count; i++)
            {
                // Adds the foundShowtimeList to the showtimeListBox
                showtimeListBox.Items.Add(foundShowtimeList[i].ID);
            }
        }

        private void DisplayUsers()
        {
            // Loops through foundUserAccountList
            for (int i = 0; i < foundUserAccountList.Count; i++)
            {
                // Checks if the UserAccountTypeID is equal to the client ID
                if (foundUserAccountList[i].UserAccountTypeID.ToString() == "1")
                {
                    // Adds the clients to clientListBox
                    clientListBox.Items.Add(foundUserAccountList[i].Name);
                }
            }
        }

        private List<Movie> GetMoviesFromDB()
        {
            foundMovieList.Clear();

            movieListBox.Items.Clear();

            Movie currentMovie;

            // Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM movietheaterschema.movie;";
            Console.WriteLine("SQL Query: " + sqlQuery);

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                //Create a new movie and setup its info
                currentMovie = new Movie();

                currentMovie.ID = dataReader.GetInt32(0);
                currentMovie.Title = dataReader.GetString(1);
                currentMovie.Year = dataReader.GetInt32(2);
                currentMovie.Length = dataReader.GetTimeSpan(3);
                currentMovie.AudienceRating = dataReader.GetDouble(4);
                currentMovie.Genre = LoadMovieGenres(currentMovie.ID);

                if (dataReader.GetString(5) == "")
                {
                    currentMovie.ImageFilePath = @"images\noimage.png";
                    foundMovieList.Add(currentMovie);
                }
                else
                {
                    currentMovie.ImageFilePath = dataReader.GetString(5);
                    foundMovieList.Add(currentMovie);
                }
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            // Calls DisplayMovies method to display the list of movies
            DisplayMovies();

            return foundMovieList;
        }

        private List<ScreeningRoom> GetScreeningRoomsFromDB()
        {
            ScreeningRoom newScreeningRoom;

            // Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM movietheaterschema.screening_room;";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            // Read each line present in the dataReader
            while (dataReader.Read())
            {
                newScreeningRoom = new ScreeningRoom();

                newScreeningRoom.Code = dataReader.GetString(0);
                newScreeningRoom.Capacity = dataReader.GetInt32(1);
                newScreeningRoom.Description = dataReader.GetString(2);

                foundScreeningRoomList.Add(newScreeningRoom);
            }

            // Close database connection
            dbConnection.Close();

            // Display screening rooms in screeningRoomListBox
            DisplayScreeningRooms();

            return foundScreeningRoomList;
        }

        private List<Showtime> GetShowtimesFromDB()
        {
            Showtime newShowtime;

            // Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM movietheaterschema.showtime;";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                newShowtime = new Showtime();

                newShowtime.ID = dataReader.GetInt32(0);
                newShowtime.DateTime = dataReader.GetDateTime(1);
                newShowtime.MovieID = dataReader.GetInt32(2);
                newShowtime.ScreeningRoomID = dataReader.GetString(3);
                newShowtime.TicketPrice = dataReader.GetDouble(4);

                foundShowtimeList.Add(newShowtime);
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            // Displays showtimes in showtimeListBox
            DisplayShowtimes();

            return foundShowtimeList;
        }

        private List<UserAccount> GetUserAccountsFromDB()
        {
            UserAccount newUserAccount;

            // Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM movietheaterschema.user_account;";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                newUserAccount = new UserAccount();

                newUserAccount.ID = dataReader.GetInt32(0);
                newUserAccount.Name = dataReader.GetString(1);
                newUserAccount.Username = dataReader.GetString(2);
                newUserAccount.Password = dataReader.GetString(3);
                newUserAccount.Email = dataReader.GetString(4);
                newUserAccount.UserAccountTypeID = dataReader.GetInt32(5);
                newUserAccount.SignUpDateTime = dataReader.GetDateTime(6);

                foundUserAccountList.Add(newUserAccount);
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            // Displays clients in clientListBox
            DisplayUsers();

            return foundUserAccountList;
        }

        private List<Genre> GetGenresFromDB()
        {
            Genre newGenre;

            // Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM movietheaterschema.genre;";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                newGenre = new Genre();

                newGenre.Code = dataReader.GetString(0);
                newGenre.Name = dataReader.GetString(1);
                newGenre.Description = dataReader.GetString(2);

                foundGenreList.Add(newGenre);
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return foundGenreList;
        }

        private List<Genre> LoadMovieGenres(int movieID)
        {
            //The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection2 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand2;
            NpgsqlDataReader dataReader2;

            //The following Connection, Command and DataReader objects will be used to access the genre table
            NpgsqlConnection dbConnection3 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand3;
            NpgsqlDataReader dataReader3;


            string currentGenreCode;

            Genre currentGenre;

            List<Genre> GenreList = new List<Genre>();

            dbConnection2.Open();

            string sqlQuery = "SELECT genre_id FROM movietheaterschema.jt_genre_movie WHERE movie_id = " + movieID + ";";

            Console.WriteLine("sqlQuery = " + sqlQuery);

            dbCommand2 = new NpgsqlCommand(sqlQuery, dbConnection2);

            dataReader2 = dbCommand2.ExecuteReader();

            //While there are genre_codes in the dataReader2
            while (dataReader2.Read())
            {
                currentGenre = new Genre();

                currentGenreCode = dataReader2.GetString(0);

                //Open a connection to access the 'genre' table
                dbConnection3.Open();

                sqlQuery = "SELECT * FROM movietheaterschema.genre WHERE genreid = '" + currentGenreCode + "';";

                Console.WriteLine("sqlQuery = " + sqlQuery);

                dbCommand3 = new NpgsqlCommand(sqlQuery, dbConnection3);

                dataReader3 = dbCommand3.ExecuteReader();

                //Read a line from the 'genre' table
                dataReader3.Read();

                currentGenre.Code = dataReader3.GetString(0);
                currentGenre.Name = dataReader3.GetString(1);
                currentGenre.Description = dataReader3.GetString(2);

                Console.WriteLine("currentGenre = " + currentGenre.Code + " - " + currentGenre.Name + " - " + currentGenre.Description);

                GenreList.Add(currentGenre);

                dbConnection3.Close();
            }

            dbConnection2.Close();

            return GenreList;
        }

        private void movieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Takes selected item in listview and reads as string
            string selectedMovie = movieListBox.SelectedItem.ToString();

            // reads all movies in movieList
            for (int i = 0; i < foundMovieList.Count; i++)
            {
                // Looks through names in movie list
                if (selectedMovie == foundMovieList[i].Title)
                {
                    // Displays all info of selected movie in text boxes
                    movieIDTextBox.Text = foundMovieList[i].ID.ToString();
                    genreTextBox.Text = foundMovieList[i].Genre.ToString();
                    titleTextBox.Text = foundMovieList[i].Title.ToString();
                    yearTextBox.Text = foundMovieList[i].Year.ToString();
                    lengthTextBox.Text = foundMovieList[i].Length.ToString();
                    audienceRatingTextBox.Text = foundMovieList[i].AudienceRating.ToString("0.##");
                    imageFilePathTextBox.Text = foundMovieList[i].ImageFilePath;
                }
            }
        }

        private void screeningRoomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Takes selected item in listview and reads as string
            string selectedScreeningRoom = screeningRoomListBox.SelectedItem.ToString();

            // reads all movies in movieList
            for (int i = 0; i < foundScreeningRoomList.Count; i++)
            {
                // Looks through names in movie list
                if (selectedScreeningRoom == foundScreeningRoomList[i].Code)
                {
                    screeningRoomCodeTextBox.Text = foundScreeningRoomList[i].Code;
                    capacityTextBox.Text = foundScreeningRoomList[i].Capacity.ToString();
                    descriptionTextBox.Text = foundScreeningRoomList[i].Description;
                }
            }
        }

        private void showtimeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Takes selected item in listbox and reads as string
            string selectedShowtime = showtimeListBox.SelectedItem.ToString();

            // reads all movies in movieList
            for (int i = 0; i < foundShowtimeList.Count; i++)
            {
                // Looks through names in movie list
                if (selectedShowtime == foundShowtimeList[i].ID.ToString())
                {
                    showtimeIDTextBox.Text = foundShowtimeList[i].ID.ToString();
                    dateTimeTextBox.Text = foundShowtimeList[i].DateTime.ToString();
                    showtimeMovieIDTextBox.Text = foundShowtimeList[i].MovieID.ToString();
                    showtimeScreenRoomCodeIDTextBox.Text = foundShowtimeList[i].ScreeningRoomID;
                    ticketPriceTextBox.Text = foundShowtimeList[i].TicketPrice.ToString("c");
                }
            }
        }

        private void deleteMovie() 
        {
            string id = movieIDTextBox.Text;

            // The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection1 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand1;
            NpgsqlDataReader dataReader1;

            dbConnection1.Open();

            //string sqlQuery = "DELETE FROM movietheaterschema.movie WHERE title = '" + id + "';";
            string sqlQuery = "DELETE FROM movietheaterschema.movie WHERE movieid = '" + id + "';";

            //This is the actual SQL containing the query to be executed
            dbCommand1 = new NpgsqlCommand(sqlQuery, dbConnection1);

            dataReader1 = dbCommand1.ExecuteReader();

            dbConnection1.Close();

            GetMoviesFromDB();
        }

        private void DisableMovieTB()
        {
            movieIDTextBox.Enabled = false;
            titleTextBox.Enabled = false;
            genreTextBox.Enabled = false;
            lengthTextBox.Enabled = false;
            audienceRatingTextBox.Enabled = false;
            yearTextBox.Enabled = false;
            imageFilePathTextBox.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            CreateManager create = new CreateManager();

            create.Show();
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            AddMovie movie = new AddMovie();

            movie.Show();
        }

        private void deleteMovieButton_Click(object sender, EventArgs e)
        {
            deleteMovie();
        }

        private void logoutButton_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();

            this.Close();
        }

        private void editMovieButton_Click(object sender, EventArgs e)
        {
            editForm edit = new editForm();

            edit.Show();

            this.Close();
        }
    }
}
