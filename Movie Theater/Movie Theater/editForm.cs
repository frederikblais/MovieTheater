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
    public partial class editForm : Form
    {
        public editForm()
        {
            InitializeComponent();

            InitGUI();

            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

            GetMoviesFromDB();


        }

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

        private void InitGUI()
        {
            movieIDTextBox.Enabled = false;

            titleTextBox.Focus();
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

        private void movieListBox_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void deleteMovie()
        {
            string id = movieIDTextBox.Text;

            // The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection1 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand1;
            NpgsqlDataReader dataReader1;

            dbConnection1.Open();

            string sqlQuery = "DELETE FROM movietheaterschema.movie WHERE movieid = '" + id + "';";

            //This is the actual SQL containing the query to be executed
            dbCommand1 = new NpgsqlCommand(sqlQuery, dbConnection1);

            dataReader1 = dbCommand1.ExecuteReader();

            dbConnection1.Close();

            GetMoviesFromDB();
        }

        private void diplayNewMovie()
        {
            // The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection1 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand1;
            NpgsqlDataReader dataReader1;

            NpgsqlConnection dbConnection2 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand2;
            NpgsqlDataReader dataReader2;

            dbConnection1.Open();

            string sqlQuery = "SELECT * FROM movietheaterschema.movie;";

            //This is the actual SQL containing the query to be executed
            dbCommand1 = new NpgsqlCommand(sqlQuery, dbConnection1);

            dataReader1 = dbCommand1.ExecuteReader();

            int[] thenumbers = { };

            while (dataReader1.Read())
            {
                int[] numbers = { dataReader1.GetInt32(0) };

                thenumbers = numbers;
            }

            dbConnection1.Close();

            int biggestNumber = thenumbers.Max();

            biggestNumber++;

            if (string.IsNullOrEmpty(titleTextBox.Text) || string.IsNullOrEmpty(yearTextBox.Text) || string.IsNullOrEmpty(lengthTextBox.Text)
                || string.IsNullOrEmpty(audienceRatingTextBox.Text) || string.IsNullOrEmpty(imageFilePathTextBox.Text))
            {
                errorMessageLabel.Visible = true;
                errorlabel2.Visible = true;
                errorlabel3.Visible = true;
                errorlabel4.Visible = true;
                errorlabel5.Visible = true;
                errorlabel6.Visible = true;
                errorlabel7.Visible = true;
            }
            else
            {
                // ADD NEW MOVIE TO MOVIE

                string sqlQuery2 = "INSERT INTO movietheater_db.movietheaterschema.movie VALUES ('" + biggestNumber + "', '" + titleTextBox.Text + "', '" +
                yearTextBox.Text + "', '" + lengthTextBox.Text + "', '" + audienceRatingTextBox.Text + "', '" + imageFilePathTextBox.Text + "'" + ");";

                dbConnection2.Open();

                dbCommand2 = new NpgsqlCommand(sqlQuery2, dbConnection2);

                dbCommand2.ExecuteNonQuery();

                dbConnection2.Close();

                MessageBox.Show("Movie Modified Succsefully.");

                this.Close();

                ManagerPortal portal = new ManagerPortal();

                portal.Show();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ManagerPortal manager = new ManagerPortal();

            manager.Show();

            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            deleteMovie();

            diplayNewMovie();
        }
    }
}
