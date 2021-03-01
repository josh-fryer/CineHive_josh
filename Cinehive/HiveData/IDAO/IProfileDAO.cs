using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinehive.Models;
using HiveData.Models.Domain;

namespace HiveData.IDAO
{
    public interface IProfileDAO
    {
        void CreateProfile(UserProfile userProfile, ApplicationDbContext context);
        UserProfile ViewProfile(int? id);
    }
}
