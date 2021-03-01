using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Cinehive.HiveData.Repository;
using Cinehive.Models;

namespace HiveData.Models
{
    public class PostComment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateCommented { get; set; }
        public int Awards { get; set; }
    }
}