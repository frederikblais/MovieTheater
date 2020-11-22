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
    public partial class CreateManager : Form
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

        public CreateManager()
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ManagerPortal portal = new ManagerPortal();

            portal.Show();

            this.Close();
        }

        private void createAccount()
        {
            // The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection1 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand1;
            NpgsqlDataReader dataReader1;

            NpgsqlConnection dbConnection2 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand2;
            NpgsqlDataReader dataReader2;

            dbConnection1.Open();

            string sqlQuery = "SELECT * FROM movietheaterschema.user_account;";
            Console.WriteLine("SQL Query: " + sqlQuery);

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

            Console.WriteLine(biggestNumber);

            biggestNumber++;

            Console.WriteLine("Added one: " + biggestNumber);

            // Get the current date.
            string dateformat = DateTime.Now.ToString("yyyy-MM-dd h:mm");


            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(emailTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                errorMessageLabel.Visible = true;
                errorlabel1.Visible = true;
                errorlabel2.Visible = true;
                errorlabel3.Visible = true;
                errorlabel4.Visible = true;
            }

            else
            {
                string sqlQuery2 = "INSERT INTO movietheater_db.movietheaterschema.user_account VALUES ('" + biggestNumber + "', '" + nameTextBox.Text + "', '" + usernameTextBox.Text + "', '" +
                passwordTextBox.Text + "', '" + emailTextBox.Text + "', '2', '" + dateformat + "'" + ");";

                Console.WriteLine("SQL Query: " + sqlQuery2);

                dbConnection2.Open();

                //This is the actual SQL containing the query to be executed
                dbCommand2 = new NpgsqlCommand(sqlQuery2, dbConnection2);

                dbCommand2.ExecuteNonQuery();

                MessageBox.Show("Account Created Succsefully.");

                this.Close();

                ManagerPortal portal = new ManagerPortal();

                portal.Show();
            }



        }

        private void createButton_Click_1(object sender, EventArgs e)
        {
            createAccount();
        }
    }
}
