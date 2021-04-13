using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.Models
{
    public class Rating
    {
        public int ID { get; set; }      
        public int Stars { get; set; } // between 1 and 5
        public DateTime Date { get; set; } // Date of rating
    }
}
