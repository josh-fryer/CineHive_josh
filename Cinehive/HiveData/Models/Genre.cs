using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }
        public Int32? ApiId { get; set; } // change of int type fixed error
        public string Name { get; set; }
    }
}
