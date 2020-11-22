using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Theater
{
    public class ScreeningRoom
    {
        public string Code { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }

        public ScreeningRoom()
        {
            Code = "";
            Capacity = 0;
            Description = "";
        }
    }
}
