using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Theater
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<Genre> Genre { get; set; }
        public int Year { get; set; }
        public TimeSpan Length { get; set; }
        public double AudienceRating { get; set; }
        public string ImageFilePath { get; set; }
        public Movie()
        {
            ID = 0;
            Title = "";
            List<Genre> Genre = new List<Genre>();
            Year = 0;
            Length = new TimeSpan();
            AudienceRating = 0;
            ImageFilePath = "";
            
        }
    }
}
