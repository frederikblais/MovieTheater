using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Theater
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
