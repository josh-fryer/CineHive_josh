using HiveData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public interface IMovieService
    {
        Movie ViewMovie(dynamic i);
        dynamic SearchMovie(string query, int? page);
        Task<dynamic> SearchMoviesAsync(string q);
        Task<List<Movie>> ToMoviesListAsync(dynamic item, int? x);
        Movie ConvertToMovie(dynamic item);
        string PrepareQuery(string query);
        Movie GetMovieByID(int id);
    }
}