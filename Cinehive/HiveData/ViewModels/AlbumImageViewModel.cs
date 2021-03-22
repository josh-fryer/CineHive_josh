using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Repository;
using HiveData.Models;

namespace HiveData.ViewModels
{
    public class AlbumImageViewModel
    {
        CineHiveContext context = new CineHiveContext();

        public IList<Image> Images { get; set; }
        public Album Album { get; set; }

    }
}
