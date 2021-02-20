using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HiveData.Models.Domain
{
    public class User
    {
       [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsVerified { get; set; }
        public bool IsRestricted { get; set; }
    }
}