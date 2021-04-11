using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models;
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
                int totalMResults = 0;

                var postResults = searchDAO.SearchPostsAsync(q, context);
                var userResults = searchDAO.SearchUsersAsync(q, context);
                var movieArr = await movieService.SearchMoviesAsync(q);
                // return max 6 to show "view more" link
                var movieResults = movieService.ToMoviesListAsync(movieArr, 6);

                if (movieArr != null)
                {
                    totalMResults = movieArr.total_results;
                }

                SearchResultsVM searchResults = new SearchResultsVM() {
                    PostResults = await postResults,
                    UserResults = await userResults,
                    MovieResults = await movieResults,
                    totalMovieResults = totalMResults
                };
                return searchResults;
            }
        }
    }
}
