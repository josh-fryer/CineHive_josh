using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HiveData.Models.Domain
{
    public class PostComment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateCommented { get; set; }
    }
}