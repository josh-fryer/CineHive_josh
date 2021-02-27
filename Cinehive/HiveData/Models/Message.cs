using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Cinehive.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiveData.Models.Domain
{
    public class Message
    {
        [Key]     
        public int MessageId { get; set; }
        [ForeignKey("User"),Column(Order =0)]
        public string SenderId { get; set; }
        [ForeignKey("UserTwo"), Column(Order = 1)]
        public string RecipientId { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageSent { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser UserTwo { get; set; }
    }
}