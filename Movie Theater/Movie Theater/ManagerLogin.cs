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
    public partial class ManagerLogin : Form
    {
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "1013";
        private const string DbName = "movietheaterdb";

        NpgsqlConnection dbConnection;
        public ManagerLogin()
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

        private void loginManagerButton_Click(object sender, EventArgs e)
        {

        }

        private void createManagerButton_Click(object sender, EventArgs e)
        {

        }

        private void closeManagerButton_Click(object sender, EventArgs e)
        {
            Login log = new Login(); // Instantiate a ManagerLogin object.
            log.Show();                            // Show ManagerLogin and
            this.Close();                          // closes the Login instance.
        }
    }
}
