using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models.Domain;
using Cinehive.Models;

namespace HiveServices.IService
{
    public interface IProfileService
    {
        void CreateProfile(UserProfile userProfile, string id);

        UserProfile ViewProfile(int? id);
    }
}
