using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.Models
{
    public class Movie
    {
        public int ID { get; set; } // unique ID needed for database to iterate
        public int MovieApi_ID { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }
        public int[] GenreIds { get; set; }
        public string Title { get; set; }
        public string VideoKey { get; set; }

        // db data fields
        public int ViewCounter {get; set;}
        public bool Trending { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

    }
}
