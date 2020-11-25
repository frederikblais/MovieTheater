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
using System.Configuration;

namespace Movie_Theater
{
    public partial class AddMovie : Form
    {
        private const string DbServerHost = "localhost";
        //private const string DbUsername = "postgres";
        private const string DbUsername = "username";
        //private const string DbUuserPassword = "yvnft9k";
        //private const string DbUuserPassword = "1013";
        private const string DbUuserPassword = "password";
        //private const string DbName = "movietheaterdb";
        private const string DbName = "movietheater_db";

        List<Genre> foundGenreList = new List<Genre>();

        NpgsqlConnection dbConnection;

        public AddMovie()
        {
            InitializeComponent();

            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

            GetGenresFromDB();
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

                genreComboBox.Items.Add(dataReader[0]);
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return foundGenreList;
        }

        private void createMovie()
        {
            // The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection1 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand1;
            NpgsqlDataReader dataReader1;

            NpgsqlConnection dbConnection2 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand2;
            NpgsqlDataReader dataReader2;

            NpgsqlConnection dbConnection3 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand3;
            NpgsqlDataReader dataReader3;

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
                || string.IsNullOrEmpty(ratingTextBox.Text) || string.IsNullOrEmpty(imageFilePathTextBox.Text))
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
                yearTextBox.Text + "', '" + lengthTextBox.Text + "', '" + ratingTextBox.Text + "', '" + imageFilePathTextBox.Text + "'" + ");";

                dbConnection2.Open();

                dbCommand2 = new NpgsqlCommand(sqlQuery2, dbConnection2);

                dbCommand2.ExecuteNonQuery();

                dbConnection2.Close();


                // ADD NEW MOVIE TO JT_GENRE_MOVIE

                string selectedGenre = genreComboBox.Text;

                string sqlQuery3 = "INSERT INTO movietheater_db.movietheaterschema.jt_genre_movie VALUES ('" + selectedGenre + "', '" + biggestNumber + "'" + ");";

                dbConnection3.Open();

                dbCommand3 = new NpgsqlCommand(sqlQuery3, dbConnection3);

                dbCommand3.ExecuteNonQuery();

                dbConnection3.Close();

                MessageBox.Show("Movie Created Succsefully.");

                this.Close();

                ManagerPortal portal = new ManagerPortal();

                portal.Show();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            createMovie();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

            ManagerPortal portal = new ManagerPortal();

            portal.Show();
        }
    }
}
