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
    public partial class Form1 : Form
    {
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "yvnft9k";
        private const string DbName = "movietheaterdb";

        NpgsqlConnection dbConnection;
        public Form1()
        {
            InitializeComponent();
       
        }

        private NpgsqlConnection CreateDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);

            return dbConnection;
        }


        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();

            this.Close();
        }
    }
}
