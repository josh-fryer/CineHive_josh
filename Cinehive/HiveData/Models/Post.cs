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
        public bool hasFilmLink { get; set; }
        public bool Edited { get; set; }
        public bool Popular { get; set; }
        public bool Shared { get; set; }
        public bool PictureChange { get; set; }
        public string Author { get; set; }
        public string AuthorPP { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }

    }
}