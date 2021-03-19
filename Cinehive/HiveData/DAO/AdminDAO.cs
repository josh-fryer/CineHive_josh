using HiveData.IDAO;
using HiveData.Models;
using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.DAO
{
    public class AdminDAO : IAdminDAO
    {
        public void BanUser(string id, CineHiveContext context)
        {
            //ApplicationUser user = context.Users.Find(id);
            //context.BannedUsers.      // add user's email address to bannedusers db table
            //    Add(new BannedUser { EmailAddress = user.Email });
            //context.Users.Remove(user);

            //context.UserProfiles.Remove();
        }
    }
}
