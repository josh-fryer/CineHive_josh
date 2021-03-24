using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;

namespace HiveServices.IService
{
    public interface IAlbumService
    {
        IList<Album> GetAlbums();
        void CreateAlbum(Album album);
        Album GetAlbum(int id);
        Image GetImage(int id);
        void EditAlbum(Album album);
        void DeleteAlbum(int id);
        void SetAsProfilePicture(Image image);
        void DeleteImageFromAlbum(int id);
    }
}
