using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HiveData.Repository;
using Cinehive.Models;
using System.Web.Mvc;

namespace HiveData.Models
{
    public class UserProfile
    {
        [Key]
        public int ProfileId { get; set; }
        public string UserId { get; set; }
        public string ImagePath { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AboutMe { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<UserProfile> Friends { get; set; }

        public ICollection<UserProfile> Followers { get; set; }
        public ICollection<UserProfile> Following { get; set; }

        public ICollection<FaveGenre> FavouriteGenres { get; set; }

        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }

        public ICollection<FriendRequest> SentFriendReq { get; set; }
        public ICollection<FriendRequest> ReceivedFriendReq { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Award> Awards  { get; set; }

        public virtual ApplicationUser User { get; set; }       
        [NotMapped]
        public HttpPostedFileBase ProfilePicture { get; set; }
        // for checkbox list of favourite genres:
        [NotMapped]
        public IList<SelectListItem> Genres { get; set; }
    }
}