using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Repository;
using Cinehive.Models;

namespace HiveData.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }
        public bool IsRead { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int? senderProfileID { get; set; }
        
        // types: "addedFriend" "friendRequestRec"
    }
}
