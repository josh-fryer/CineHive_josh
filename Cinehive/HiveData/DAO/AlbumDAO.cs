using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiveData.IDAO;
using HiveData.Models;
using Microsoft.AspNet.Identity;
using HiveData.Repository;

namespace HiveData.DAO
{
    public class AlbumDAO : IAlbumDAO
    {
        public IList<Album> GetAlbums(CineHiveContext context)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();

            var user = context.UserProfiles.Where(c => c.UserId == userid).FirstOrDefault();
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
            context.SaveChanges();
        }
        public Album GetAlbum(int id, CineHiveContext context)
        {
            return context.Albums.Find(id);
        }

    }
}
