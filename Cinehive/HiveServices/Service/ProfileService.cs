using System;
using HiveData.Repository;
using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models;
using HiveServices.IService;
using System.IO;
using Microsoft.AspNet.Identity;
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
            return profileDAO.ViewProfile(id);
        }

        public void UploadService(UserProfile userProfile, Image image)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            string extension = Path.GetExtension(userProfile.ProfilePicture.FileName);
            string filename = string.Empty;
            filename = userid + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + extension;
            string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Img/ProfileImages/");
            string fullPath = "Content/Img/ProfileImages/" + filename;
            userProfile.ImagePath = fullPath;
            userProfile.ProfilePicture.SaveAs(Path.Combine(imagePath, filename));

            Image image1 = new Image()
            {
                ImagePath = fullPath
            };
            using (var context = new CineHiveContext())
            {
                context.Images.Add(image1);
                context.SaveChanges();
            }

        }
        public UserProfile GetUserProfile(string userId)
        {
            using (var context = new CineHiveContext())
            {
                return profileDAO.GetUserProfile(userId, context);
            }
        }

        public void ClearFaveGenres(string userId)
        {
            // clear all favourite genres
            using (var context = new CineHiveContext())
            {
                profileDAO.ClearFaveGenres(userId, context);
            }
        }

        public void AddFaveGenre(int genreId, string userId)
        {
            using (var context = new CineHiveContext())
            {
                profileDAO.AddFaveGenre(genreId, userId, context);
            }
        }
        public void EditProfile(UserProfile userProfile)
        {
            using (var context = new CineHiveContext())
            {

                profileDAO.EditProfile(userProfile, context);
                context.SaveChanges();
            }
        }

    }
}
