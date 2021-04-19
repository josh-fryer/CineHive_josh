using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace HiveData.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumDesc { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}
