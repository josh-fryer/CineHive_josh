using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveServices.IService;
using HiveData.IDAO;
using HiveData.DAO;
using HiveData.Models;
using HiveData.Repository;
using System.Web;
using Microsoft.AspNet.Identity;

namespace HiveServices.Service
{
    public class AlbumService : IAlbumService
    {
        private IAlbumDAO albumDAO;

        public AlbumService()
        {
            albumDAO = new AlbumDAO();
        }
        public IList<Album> GetAlbums(string userId)
        {
            using (var context = new CineHiveContext())
            {
                return albumDAO.GetAlbums(userId, context);
            }
        }
        public void CreateAlbum(string input1, string input2)
        {
            using (var context = new CineHiveContext())
            {
                albumDAO.CreateAlbum(input1,input2, context);
                context.SaveChanges();
            }
        }
        public Album GetAlbum(int id)
        {
            using (var context = new CineHiveContext())
            {
                return albumDAO.GetAlbum(id, context);
            }
        }
        public Image GetImage(int id)
        {
            using (var context = new CineHiveContext())
            {
                return albumDAO.GetImage(id, context);
            }
        }
        public void EditAlbum(Album album)
        {
            using (var context = new CineHiveContext())
            {
                albumDAO.EditAlbum(album, context);
                context.SaveChanges();
            }
        }
        public void DeleteAlbum(int id)
        {
            using (var context = new CineHiveContext())
            {
                Album album = albumDAO.GetAlbum(id, context);
                albumDAO.DeleteAlbum(album, context);
                context.SaveChanges();
            }
        }
        public void SetAsProfilePicture(Image image)
        {
            using (var context = new CineHiveContext())
            {
                albumDAO.SetAsProfilePicture(image, context);
                context.SaveChanges();
            }
        }
        public void DeleteImageFromAlbum(int id)
        {
            using (var context = new CineHiveContext())
            {
                Image image = albumDAO.GetImage(id, context);
                albumDAO.DeleteImageFromAlbum(image, context);
                context.SaveChanges();
            }
        }
        public void AddImageToAlbum(Album album, int id)
        {
            using (var context = new CineHiveContext())
            {
                albumDAO.AddImageToAlbum(id, album, context);
                context.SaveChanges();
            }
        }
        public void DeleteImagesInAlbum(int id)
        {
            using (var context = new CineHiveContext())
            {
                albumDAO.DeleteImagesInAlbum(id, context);
                context.SaveChanges();
            }
        }
    }
}
