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

namespace HiveServices.Service
{
    public class AlbumService : IAlbumService
    {
        private IAlbumDAO albumDAO;

        public AlbumService()
        {
            albumDAO = new AlbumDAO();
        }
        public IList<Album> GetAlbums()
        {
            using (var context = new CineHiveContext())
            {
                return albumDAO.GetAlbums(context);
            }
        }
        public void CreateAlbum(Album album)
        {
            using (var context = new CineHiveContext())
            {
                albumDAO.CreateAlbum(album, context);
            }
        }
        public Album GetAlbum(int id)
        {
            using (var context = new CineHiveContext())
            {
                return albumDAO.GetAlbum(id, context);
            }
        }
    }
}
