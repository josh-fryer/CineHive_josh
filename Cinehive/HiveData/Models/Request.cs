using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HiveData.Models.Domain
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int ReqSenderId { get; set; }
        public int ReqRecipientId { get; set; }
        public DateTime ReqDateSent { get; set; }
        [Range(0,2)]
        public int ReqStatus { get; set; } //Could have bool here but wasnt sure, 0 = pending, 1 = accepted, 2 = Declined
        //or could be Bool of accepted
    }
}