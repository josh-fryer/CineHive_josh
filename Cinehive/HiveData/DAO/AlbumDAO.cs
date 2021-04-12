﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiveData.IDAO;
using HiveData.Models;
using Microsoft.AspNet.Identity;
using HiveData.Repository;
using System.IO;
using System.Data.Entity;

namespace HiveData.DAO
{
    public class AlbumDAO : IAlbumDAO
    {
        public IList<Album> GetAlbums(string userId, CineHiveContext context)
        {
            var user = context.UserProfiles.Where(c => c.UserId == userId).FirstOrDefault();
            var result = user.Albums.ToList();
            return result;
        }

        public void CreateAlbum(Album album, CineHiveContext context)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();

            UserProfile userProfile = context.UserProfiles.First(x => x.UserId == userid);

            album = new Album()
            {
                AlbumName = album.AlbumName,
                AlbumDesc = album.AlbumDesc
            };

            userProfile.Albums.Add(album);
        }

        public Album GetAlbum(int id, CineHiveContext context)
        {
            return context.Albums.Find(id);
        }

        public Image GetImage(int id, CineHiveContext context)
        {
            return context.Images.Find(id);
        }

        public void EditAlbum(Album album, CineHiveContext context)
        {
            context.Entry(album).State = EntityState.Modified;
        }

        public void DeleteAlbum(Album album, CineHiveContext context)
        {
            context.Albums.Remove(album);
        }

        public void DeleteImagesInAlbum(int id, CineHiveContext context)
        {
            var images = context.Albums.Find(id).Images.ToList();
            foreach (var item in images)
            {
                context.Images.Remove(item);
            }
        }

        public void SetAsProfilePicture(Image image, CineHiveContext context)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            int id = context.UserProfiles.Where(x => x.UserId == userid).Select(c => c.ProfileId).FirstOrDefault();

            UserProfile userProfile = context.UserProfiles.Find(id);

            userProfile.ImagePath = image.ImagePath;

            context.Entry(userProfile).State = EntityState.Modified;
        }

        public void DeleteImageFromAlbum(Image image, CineHiveContext context)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            string filename = image.Filename;
            string path = HttpContext.Current.Server.MapPath("~/Content/Img/UserImg/" + userid + "/" + filename);
            FileInfo file = new FileInfo(path);
            file.Delete();

            context.Images.Remove(image);
        }

        public void AddImageToAlbum(int id, Album album, CineHiveContext context)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            string extension = Path.GetExtension(album.UploadImage.FileName);
            string filename = string.Empty;

            filename = userid + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + extension;
            string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Img/UserImg/" + userid);

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            string fullPath = "Content/Img/UserImg/" + userid + "/" + filename;
            album.UploadImage.SaveAs(Path.Combine(imagePath, filename));

            album = context.Albums.Find(id);

            Image image1 = new Image()
            {
                ImagePath = fullPath,
                Filename = filename
            };

            album.Images.Add(image1);
        }

    }
}
