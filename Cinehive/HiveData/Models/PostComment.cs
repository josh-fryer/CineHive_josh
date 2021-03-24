using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HiveData.Repository;
using Cinehive.Models;

namespace HiveData.Models
{
    public class PostComment
    {
        [Key]
        public int CommentId { get; set; }
        [Display(Name = "Comment Content")]
        public string CommentContent { get; set; }
        [Display(Name ="Date Commented")]
        public DateTime DateCommented { get; set; }
        public int Awards { get; set; }
        public bool Edited { get; set; }
    }
}