using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Repository;
using Cinehive.Models;
using HiveData.Models;

namespace HiveData.IDAO
{
    public interface IProfileDAO
    {
        void CreateProfile(UserProfile userProfile, CineHiveContext context);
        UserProfile ViewProfile(int? id);
        UserProfile GetUserProfile(string userId, CineHiveContext context);
        void ClearFaveGenres(string userId, CineHiveContext context);
        void AddFaveGenre(int genreId, string userid, CineHiveContext context);
        void EditProfile(UserProfile userProfile, CineHiveContext context);
    }
}
