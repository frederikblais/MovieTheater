using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Theater
{
    public class E_Ticket
    {
        public int ID { get; set; }
        public TimeSpan PurchaseDate { get; set; }
        public int ShowtimeID { get; set; }
        public int UserAccountID { get; set; }

        public E_Ticket()
        {
            ID = 0;
            PurchaseDate = new TimeSpan();
            ShowtimeID = 0;
            UserAccountID = 0;
        }
    }
}
