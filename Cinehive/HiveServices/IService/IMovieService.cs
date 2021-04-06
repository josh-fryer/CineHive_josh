using HiveData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public interface IMovieService
    {
        Movie ViewMovie(dynamic i);
        dynamic SearchMovie(string query);
        Task<IList<Movie>> SearchMoviesAsync(string q);
        string PrepareQuery(string query);
    }
}