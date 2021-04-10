using HiveData.Models;
using HiveData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HiveData.Repository;
using HiveServices.Service;
using PagedList;

namespace Cinehive.Controllers
{
    public class SearchController : Controller
    {
        private ISearchService searchService;
        private IMovieService movieService;

        private CineHiveContext context = new CineHiveContext();
        public SearchController()
        {
            searchService = new SearchService();
            movieService = new MovieService();
        }

        public async Task<ActionResult> Search(string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                string q = query.Trim();
                ViewBag.query = q;
                return View(await searchService.Search(q));
            }
            
            return View(new SearchResultsVM());
        }


        public ActionResult FilteredSearch(string query, string type, int? page)
        {
            //string q = query.Trim(); already trimming query from Search()
            FilteredSearchVM filteredSearch = new FilteredSearchVM();
            int pageSize = 10;
            int pageNumber = (page ?? 1); // if null page = 1
            dynamic pagedResults; // has to be declared here
            
            // search the required type:
            switch (type)
            {
                case "post":
                    List<Post> results = new List<Post>();
                    // search posts for query by latest first
                    var orderedPosts = context.Posts.OrderByDescending(p => p.DatePosted).ToList();                      
                    for (int i = 0; i < orderedPosts.Count; i++)
                    {
                        Post p = orderedPosts[i];
                        if (!String.IsNullOrEmpty(p.PostContent))
                        {
                            if (p.PostContent.Contains(query)) // case sensitive
                            {
                                results.Add(p);
                            }
                        }
                    }
                    pagedResults = results.ToPagedList(pageNumber, pageSize);
                    filteredSearch.PostList = pagedResults;
                    break;
                case "user":
                    List<UserProfile> userResults = new List<UserProfile>();

                    userResults = context.UserProfiles.Where(x => x.Firstname.Contains(query) || x.Firstname.ToLower().Contains(query) ||
                        x.Firstname.ToUpper().Contains(query) || x.Lastname.Contains(query) || x.Lastname.ToLower().Contains(query)
                        || x.Lastname.ToUpper().Contains(query)).ToList();
                    
                    pagedResults = userResults.ToPagedList(pageNumber, pageSize);
                    filteredSearch.UserList = pagedResults;
                    break;
                case "movie":
                    //string prepQuery = movieService.PrepareQuery(query);
                    var movies = movieService.SearchMovie(query, pageNumber);
                   
                    // convert 10 results to Movie obj. + to List
                    List<Movie> moviePageResults = new List<Movie>();                  
                    for (int i = 0; i < 10 && i < ((Newtonsoft.Json.Linq.JContainer)movies.results).Count; i++)
                    {
                        moviePageResults.Add(movieService.ConvertToMovie(movies.results[i]));
                    }

                    ViewBag.totalMovieResults = movies.total_results;
                    ViewBag.totalPages = movies.total_pages;
                    ViewBag.moviePageNum = pageNumber;                  
                    
                    //pagedResults = moviePageResults.ToPagedList(pageNumber, pageSize);
                    filteredSearch.MovieList = moviePageResults;
                    break;
                default:
                    return View(filteredSearch);
            }

            ViewBag.query = query;
            ViewBag.type = type;

            return View(filteredSearch);
        }

    }
}