using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Theater
{
    public class Showtime
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public int MovieID { get; set; }
        public string ScreeningRoomID { get; set; }
        public double TicketPrice { get; set; }

        public Showtime()
        {
            ID = 0;
            DateTime = new DateTime();
            MovieID = 0;
            ScreeningRoomID = "";
            TicketPrice = 0;
        }
    }
}
