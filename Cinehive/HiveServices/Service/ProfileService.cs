using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinehive.HiveData.Repository;
using Cinehive.Models;
using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models;
using HiveServices.IService;

namespace HiveServices.Service
{
    public class ProfileService : IProfileService
    {
        private IProfileDAO profileDAO;
        public ProfileService()
        {
            profileDAO = new ProfileDAO();
        }
        public void CreateProfile(UserProfile userProfile, string id)
        {
            UserProfile userProfile1 = new UserProfile()
            {
                Firstname = userProfile.Firstname,
                Lastname = userProfile.Lastname,
                Gender = userProfile.Gender,
                DateOfBirth = userProfile.DateOfBirth,
                AboutMe = userProfile.AboutMe

            };
            using (var context = new CineHiveContext())
            {
                profileDAO.CreateProfile(userProfile, context);
                context.SaveChanges();
            }
        }
        public UserProfile ViewProfile(int? id)
        {
            profileDAO = new ProfileDAO();
            return profileDAO.ViewProfile(id);
        }
    }
}
