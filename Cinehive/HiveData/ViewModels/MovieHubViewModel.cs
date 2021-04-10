using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;

namespace HiveData.ViewModels
{
    public class MovieHubViewModel
    {
        public Movie LatestMovie { get; set; }
        public IList<Movie> Movies { get; set; }
        public IList<Movie> UpcomingMovie { get; set; }
        public IList<Movie> PopAmongCritic { get; set; }

    }
}
