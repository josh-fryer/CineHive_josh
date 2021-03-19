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
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsAccepted { get; set; }
    }

}
