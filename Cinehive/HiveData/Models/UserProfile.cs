using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HiveData.Models.Domain
{
    public class UserProfile
    {
        [Key]
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AboutMe { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
    }
}