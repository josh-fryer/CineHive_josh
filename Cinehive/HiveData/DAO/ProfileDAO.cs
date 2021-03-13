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

        public UserProfile GetUserProfile(int? id)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            var GetProfile = Context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();
            id = GetProfile;
            return Context.UserProfiles.Find(id);
        }

        public void ClearFaveGenres(string userId, CineHiveContext context)
        {
            IList<FaveGenre> faveGenres = 
                context.FaveGenres.Where(x => x.UserId == userId).ToList();
            context.FaveGenres.RemoveRange(faveGenres);
            context.SaveChanges();
        }

        public void AddFaveGenre(int genreId, string userId, CineHiveContext context)
        {
            FaveGenre newFaveGenre = new FaveGenre()
            {
                UserId = userId,
                GenreId = genreId
            };
            context.FaveGenres.Add(newFaveGenre);
            context.SaveChanges();
        }
    }
}