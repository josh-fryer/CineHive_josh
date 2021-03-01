using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinehive.HiveData.Repository;
using Cinehive.Models;

namespace HiveData.Models
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User"), Column(Order = 1)]
        public string SenderId { get; set; }
        [ForeignKey("UserTwo"), Column(Order = 2)]
        public string ReceiverId { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsAccepted { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser UserTwo { get; set; }
    }

}
