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
        IList<Album> GetAlbums(string userId);
        void CreateAlbum(string input1, string input2);
        Album GetAlbum(int id);
        Image GetImage(int id);
        void EditAlbum(Album album);
        void DeleteAlbum(int id);
        void SetAsProfilePicture(Image image);
        void DeleteImageFromAlbum(int id);
        void AddImageToAlbum(Album album, int id);
        void DeleteImagesInAlbum(int id);
    }
}
