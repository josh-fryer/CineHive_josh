using HiveData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public interface IMovieService
    {
        Movie ViewMovie(dynamic i);
        dynamic SearchMovie(string query, int? page = 1, int? year = 0);
        Task<dynamic> SearchMoviesAsync(string q);
        Task<List<Movie>> ToMoviesListAsync(dynamic item, int? x);
        Movie ConvertToMovie(dynamic item);
        Movie GetMovieByID(int id);
        void RateMovie(int movieApiID, int stars, string userId);
        int GetUserRating(string userID, int movieApiID);
        //void GetGenresToDb();
    }
}