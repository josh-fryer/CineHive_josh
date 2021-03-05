using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Repository;
using Cinehive.Models;
using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models;
using HiveServices.IService;
using System.IO;
using Microsoft.AspNet.Identity;
using HiveServices.Service;
using System.Data.Entity;
using System.Net;
using System.Web;


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

        public void UploadService(UserProfile userProfile)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            string extension = Path.GetExtension(userProfile.ProfilePicture.FileName);
            string filename = string.Empty;
            filename = userid + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + extension;
            string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Img/ProfileImages/");
            userProfile.ImagePath = "Content/Img/ProfileImages/" + filename;
            userProfile.ProfilePicture.SaveAs(Path.Combine(imagePath, filename));
        }

    }
}
