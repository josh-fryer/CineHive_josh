using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.IDAO;
using HiveData.Models;
using Cinehive.Models;
using HiveData.Repository;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace HiveData.DAO
{
    public class ProfileDAO : IProfileDAO
    {
        CineHiveContext Context = new CineHiveContext();
        public void CreateProfile(UserProfile userProfile, CineHiveContext context)
        {
            context.UserProfiles.Add(userProfile);
        }

        public UserProfile ViewProfile(int? id)
        {
            return Context.UserProfiles.Find(id);
        }

        public UserProfile GetUserProfile(string userId, CineHiveContext context)
        {           
            return context.UserProfiles.First(u=>u.UserId == userId);
        }

        public void ClearFaveGenres(string userId, CineHiveContext context)
        {
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            profile.FavouriteGenres.Clear();
            context.SaveChanges();
        }

        public void AddFaveGenre(int genreId, string userId, CineHiveContext context)
        {
            FaveGenre newFaveGenre = new FaveGenre()
            {             
                GenreId = genreId
            };

            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            profile.FavouriteGenres.Add(newFaveGenre);

            context.SaveChanges();
        }
        public void EditProfile(UserProfile userProfile, CineHiveContext context)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            int id = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();

            userProfile.UserId = userid;
            userProfile.ProfileId = id;

            context.Entry(userProfile).State = EntityState.Modified;

            if (userProfile.ProfilePicture == null)
            {
                context.Entry(userProfile).Property(x => x.ImagePath).IsModified = false;
            }
            if (userProfile.DateOfBirth == null)
            {
                context.Entry(userProfile).Property(z => z.DateOfBirth).IsModified = false;
            }
            if (userProfile.Gender == null)
            {
                context.Entry(userProfile).Property(v => v.Gender).IsModified = false;
            }
            if (userProfile.Privacy == 0)
            {
                context.Entry(userProfile).Property(v => v.Privacy).IsModified = false;
            }
        }
    }
}