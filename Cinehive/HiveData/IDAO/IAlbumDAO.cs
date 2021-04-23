using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;
using HiveData.Repository;

namespace HiveData.IDAO
{
    public interface IAlbumDAO
    {
        IList<Album> GetAlbums(string userId, CineHiveContext context);
        void CreateAlbum(string AlbumNameInput, string AlbumDescInput, CineHiveContext context);
        Album GetAlbum(int id, CineHiveContext context);
        Image GetImage(int id, CineHiveContext context);
        void EditAlbum(Album album, CineHiveContext context);
        void DeleteAlbum(Album album, CineHiveContext context);
        void SetAsProfilePicture(Image image, CineHiveContext context);
        void DeleteImageFromAlbum(Image image, CineHiveContext context);
        void AddImageToAlbum(int id, Album album, CineHiveContext context);
        void DeleteImagesInAlbum(int id, CineHiveContext context);
    }
}
