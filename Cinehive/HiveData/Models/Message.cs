using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HiveData.Models.Domain
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageSent { get; set; }
    }
}