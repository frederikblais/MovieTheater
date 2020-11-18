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
        private const string DbUuserPassword = "1013";
        private const string DbName = "movietheaterdb";

        NpgsqlConnection dbConnection;
        public Login()
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            /*
             * Code to validate creds goes here
             */

            // Open the Client portal if logins are ok
            Form1 f1 = new Form1();               // Instantiate a ManagerLogin object.
            f1.Show();                            // Show ManagerLogin and
            this.Hide();                          // closes the Login instance.
        }

        private void createButton_Click(object sender, EventArgs e)
        {

        }

        private void managerButton_Click(object sender, EventArgs e)
        {
            ManagerLogin ml = new ManagerLogin(); // Instantiate a ManagerLogin object.
            ml.Show();                            // Show ManagerLogin and
            this.Hide();                          // closes the Login instance.
        }
    }
}
