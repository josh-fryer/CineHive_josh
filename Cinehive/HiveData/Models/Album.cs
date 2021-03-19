using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumDesc { get; set; }
        public ICollection<Image> Images { get; set; } 
    }
}
