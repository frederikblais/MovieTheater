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
    public partial class Login : Form
    {
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "yvnft9k";
        private const string DbName = "movietheaterdb";

        NpgsqlConnection dbConnection;
        public Login()
        {
            InitializeComponent();
        }

        private NpgsqlConnection CreateDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);

            return dbConnection;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection1 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand1;
            NpgsqlDataReader dataReader1;

            string username = usernameTextBox.Text;
            string password= passwordTextBox.Text;
            int usertype = 1;
            dbConnection1.Open();

            string sqlQuery = "select * from movietheaterdb.movietheaterschema.user_account;";
            Console.WriteLine("SQL Query: " + sqlQuery);

            //This is the actual SQL containing the query to be executed
            dbCommand1 = new NpgsqlCommand(sqlQuery, dbConnection1);

            dataReader1 = dbCommand1.ExecuteReader();

            while (dataReader1.Read())
            {
                if (usertype == dataReader1.GetInt32(5))
                {
                    if(username == dataReader1.GetString(2))
                    {
                        if (password == dataReader1.GetString(3))
                        {
                            this.Hide();

                            ManagerPortal f1 = new ManagerPortal();
                            f1.Show();
                        }

                        else
                        {
                            errorMessageLabel.Visible = true;
                        }
                    }

                    else
                    {
                        errorMessageLabel.Visible = true;
                    }
                }
            }

            dbConnection1.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            CreateAccount createAccount = new CreateAccount();

            createAccount.Show();

            
        }

        private void managerButton_Click(object sender, EventArgs e)
        {
            ManagerLogin ml = new ManagerLogin(); // Instantiate a ManagerLogin object.
            ml.Show();                            // Show ManagerLogin and
            this.Hide();                          // closes the Login instance.
        }
    }
}
