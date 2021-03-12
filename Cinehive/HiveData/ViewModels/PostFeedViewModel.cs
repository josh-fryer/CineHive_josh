using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;
using HiveData.Repository;

namespace HiveData.ViewModels
{
    public class PostFeedViewModel
    {
        public int PostId { get; set; }
        public string ImagePath { get; set; }
        public DateTime DatePosted { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Image Image { get; set; }
        public Post Post { get; set; }
    }
}
