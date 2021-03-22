using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiveData.Repository;

namespace HiveData.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public string Filename { get; set; }

    }
}
