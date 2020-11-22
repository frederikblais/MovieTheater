using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Theater
{
    public class UserAccount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserAccountTypeID { get; set; }
        public DateTime SignUpDateTime { get; set; }

        public UserAccount()
        {
            ID = 0;
            Name = "";
            Username = "";
            Password = "";
            Email = "";
            UserAccountTypeID = 0;
            SignUpDateTime = new DateTime();
        }
    }
}
