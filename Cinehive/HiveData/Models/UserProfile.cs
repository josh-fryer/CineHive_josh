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
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name ="Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name ="About me")]
        public string AboutMe { get; set; }
        [Display(Name = "Privacy Level")]
        public int Privacy { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserProfile> Friends { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }

        public virtual ICollection<UserProfile> Followers { get; set; }
        public virtual ICollection<UserProfile> Following { get; set; }

        public virtual ICollection<FaveGenre> FavouriteGenres { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public virtual ICollection<FriendRequest> SentFriendReq { get; set; }
        public virtual ICollection<FriendRequest> ReceivedFriendReq { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Award> Awards  { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ApplicationUser User { get; set; }       
        [NotMapped]
        public HttpPostedFileBase ProfilePicture { get; set; }
        // for checkbox list of favourite genres:
        [NotMapped]
        public IList<SelectListItem> Genres { get; set; }
    }
}