using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Cinehive.Models;
using System.ComponentModel.DataAnnotations.Schema;
using HiveData.Repository;

namespace HiveData.Models
{
    public class Message
    {    
        [Key]
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageSent { get; set; }
    }
}