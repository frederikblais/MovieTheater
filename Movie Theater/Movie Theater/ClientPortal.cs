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
    public partial class ClientPortal : Form
    {
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        //private const string DbUsername = "username"
        //private const string DbUuserPassword = "yvnft9k";
        //private const string DbUuserPassword = "password";
        private const string DbUuserPassword = "1013";
        //private const string DbName = "movietheater_db";
        private const string DbName = "movietheaterdb";

        NpgsqlConnection dbConnection;

        List<Showtime> foundShowtimeList = new List<Showtime>();
        public ClientPortal()
        {
            InitializeComponent();

            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
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

        private void DisplayShowtimes()
        {
            // Loops through foundShowTimeList
            for (int i = 0; i < foundShowtimeList.Count; i++)
            {
                // Adds the foundShowtimeList to the showtimeListBox
                movieShowtimeListBox.Items.Add(foundShowtimeList[i].DateTime.ToString());
            }
        }

        private List<Showtime> GetShowtimesFromDB()
        {
            Showtime currentShowtime;

            // Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM movietheaterschema.showtime;";
            Console.WriteLine("SQL Query: " + sqlQuery);

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                currentShowtime = new Showtime();

                currentShowtime.ID = dataReader.GetInt32(0);
                currentShowtime.DateTime = dataReader.GetDateTime(1);
                currentShowtime.MovieID = dataReader.GetInt32(2);
                currentShowtime.ScreeningRoomID = dataReader.GetString(3);
                currentShowtime.TicketPrice = dataReader.GetDouble(4);

                foundShowtimeList.Add(currentShowtime);
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            // Calls DisplayMovies method to display the list of movies
            DisplayShowtimes();

            return foundShowtimeList;
        }

        /*private List<Genre> LoadShowtimeMovies(int movieID)
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

            string sqlQuery = "SELECT genrecode FROM oopproject4schema.jtgenremovie WHERE movieid = " + movieID + ";";

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

                sqlQuery = "SELECT * FROM oopproject4schema.genre WHERE genrecode = '" + currentGenreCode + "';";

                Console.WriteLine("sqlQuery = " + sqlQuery);

                dbCommand3 = new NpgsqlCommand(sqlQuery, dbConnection3);

                dataReader3 = dbCommand3.ExecuteReader();

                //Read a line from the 'genre' table
                dataReader3.Read();

                currentGenre.Code = dataReader3.GetString(0);
                currentGenre.Name = dataReader3.GetString(1);
                currentGenre.Description = dataReader3.GetString(2);

                Console.WriteLine("currentGenre = " + currentGenre.Code + " - " + currentGenre.Name + " - " + currentGenre.Description);

                //dbCommand3.Dispose();
                //dataReader3.Close();

                GenreList.Add(currentGenre);

                dbConnection3.Close();
            }

            dbConnection2.Close();

            return GenreList;
        }*/

    }
}
