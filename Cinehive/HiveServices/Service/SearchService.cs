using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Repository;
using HiveData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public class SearchService : ISearchService
    {
        private ISearchDAO searchDAO;
        private IMovieService movieService;

        public SearchService()
        {
            searchDAO = new SearchDAO();
            movieService = new MovieService();
        }

        public async Task<SearchResultsVM> Search(string q)
        {
            using (var context = new CineHiveContext())
            {
                var postResults = searchDAO.SearchPostsAsync(q, context);
                var userResults = searchDAO.SearchUsersAsync(q, context);
                var movieResults = await movieService.SearchMoviesAsync(q);             

                SearchResultsVM searchResults = new SearchResultsVM()
                {
                    PostResults = await postResults,
                    UserResults = await userResults,
                    MovieResults = movieResults
                };
                return searchResults;
            }
        }
    }
}
