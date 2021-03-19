using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HiveData.Repository;

namespace HiveData.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }       
        public string PostContent { get; set; }
        public DateTime DatePosted { get; set; }
        public int Awards { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }
}