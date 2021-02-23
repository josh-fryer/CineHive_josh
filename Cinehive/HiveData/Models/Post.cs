using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cinehive.Models;

namespace HiveData.Models.Domain
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public virtual ApplicationUser UserId { get; set; }
        public string PostContent { get; set; }
        public DateTime DatePosted { get; set; }
    }
}