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
        UserProfile GetUserProfile(int? id);
    }
}
