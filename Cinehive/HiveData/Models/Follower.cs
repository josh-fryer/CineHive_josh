using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiveData.Models.Domain
{
    public class Follower
    {
        [Key]
        [Column(Order=0)]
        public int FollowerId { get; set; }
        [Key]
        [Column(Order=1)]
        public int FollowingId { get; set; }
        public DateTime DateFollowed { get; set; }
    }
}