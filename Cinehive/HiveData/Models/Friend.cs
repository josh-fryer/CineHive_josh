using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Repository;
using Cinehive.Models;

namespace HiveData.Models
{
    public class Friend
    {
        [Key]
        [ForeignKey("User"), Column(Order = 1)]
        public string MainUserId { get; set; }
        [Key]
        [ForeignKey("UserTwo"), Column(Order =2)]
        public string FriendUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser UserTwo { get; set; }


    }
}
