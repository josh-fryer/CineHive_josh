using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.Models
{
    public class FaveGenre
    {
        public int ID { get; set; }
        public int GenreId { get; set; }
    }
}


