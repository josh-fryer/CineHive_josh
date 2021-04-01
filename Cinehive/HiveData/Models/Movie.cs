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
        public int id { get; set; }
        public string poster_path { get; set; }
        public string overview { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime release_date { get; set; }
        public int[] genre_ids { get; set; }
        public string title { get; set; }

    }
}
