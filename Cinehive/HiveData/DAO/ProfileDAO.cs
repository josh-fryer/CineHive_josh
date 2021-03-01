using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.IDAO;
using HiveData.Models;
using Cinehive.Models;
using Cinehive.HiveData.Repository;

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
    }
}
