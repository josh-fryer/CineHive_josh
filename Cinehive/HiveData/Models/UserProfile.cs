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
    public class UserProfile
    {
        [Key]
        public int ProfileId { get; set; }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AboutMe { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Friend> Friends { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}