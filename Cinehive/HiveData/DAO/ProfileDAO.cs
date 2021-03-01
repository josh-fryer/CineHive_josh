using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.IDAO;
using HiveData.Models.Domain;
using Cinehive.Models;

namespace HiveData.DAO
{
    public class ProfileDAO : IProfileDAO
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        public void CreateProfile(UserProfile userProfile, ApplicationDbContext context)
        {
            context.UserProfiles.Add(userProfile);
        }
        public UserProfile ViewProfile(int? id)
        {
            return Context.UserProfiles.Find(id);
        }
        
    }
}
