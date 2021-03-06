﻿using System;
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
    public partial class ManagerLogin : Form
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
        public ManagerLogin()
        {
            InitializeComponent();

            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

            this.ActiveControl = usernameTextBox;
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

        private void loginManagerButton_Click(object sender, EventArgs e)
        {
            // The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection1 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand1;
            NpgsqlDataReader dataReader1;

            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            int usertype = 2;
            dbConnection1.Open();

            string sqlQuery = "select * from movietheaterschema.user_account;";
            Console.WriteLine("SQL Query: " + sqlQuery);

            //This is the actual SQL containing the query to be executed
            dbCommand1 = new NpgsqlCommand(sqlQuery, dbConnection1);

            dataReader1 = dbCommand1.ExecuteReader();

            while (dataReader1.Read())
            {
                if (usertype == dataReader1.GetInt32(5))
                {
                    if (username == dataReader1.GetString(2))
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

        private void createManagerButton_Click(object sender, EventArgs e)
        {

        }

        private void closeManagerButton_Click(object sender, EventArgs e)
        {
            Login log = new Login();               // Instantiate a ManagerLogin object.
            log.Show();                            // Show ManagerLogin and
            this.Close();                          // closes the Login instance.
        }
    }
}
