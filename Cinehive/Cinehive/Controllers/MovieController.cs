using HiveData.Models;
using HiveServices.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HiveData.ViewModels;
using Microsoft.AspNet.Identity;

namespace Cinehive.Controllers
{
    public class MovieController : Controller
    {
        /* ################### Api links ####################
        https://developers.themoviedb.org/3/getting-started/introduction
        For list of poster and other image sizes:
        https://developers.themoviedb.org/3/configuration/get-api-configuration
        #####################################################*/

        private readonly MovieService movieService;
      
        public MovieController()
        {
            movieService = new MovieService();
        }

        public ActionResult Index(Movie movie, dynamic item)
        {
            var upcoming = movieService.PrepUpcomingMovies(item);
            var popcritic = movieService.PrepCriticallyAcclaimed(item);
            var intheatres = movieService.PrepInTheatres(item);
            MovieHubViewModel movieHubViewModel = new MovieHubViewModel
            {
                LatestMovie = movieService.LatestMovie(movie),
                UpcomingMovie = movieService.GetUpcomingMovies(upcoming), 
                CritAcclaim = movieService.GetCriticallyAcclaimed(popcritic),
                InTheatres = movieService.GetInTheatres(intheatres)
            };      

            return View(movieHubViewModel);
        }

        // search for movie title then return view of movie details
        public ActionResult GetPostMovie(string query, int year = 0)
        {
            if (String.IsNullOrEmpty(query))
            {
                return View();
            }

            var movies = movieService.SearchMovie(query, 1, year);
            Movie movie = movieService.ViewMovie(movies);

            return RedirectToAction("ViewMovie", movie);
        }

        public ActionResult GetMovieByID(int id)
        {
            Movie movie = movieService.GetMovieByID(id);
            return RedirectToAction("ViewMovie", movie);
        }

        //[Route("Movie/ViewMovie/{movie:Movie}")]       
        public ActionResult ViewMovie(Movie movie, bool addView = true)
        {
            if (addView)
            {
                // check if movie needs adding to db and add view to counter
                movieService.AddToMoviesOrAddView(movie);
            }
                                 
            return View(movie);
        }

        // overload version by movie's Api ID
        //[Route("Movie/ViewMovie/{movieApiID:int}")]
        [ActionName("ViewMovieByID")]
        public ActionResult ViewMovie(int movieApiID, bool addView = true)
        {
            Movie movie = movieService.GetMovieByID(movieApiID);
            if (addView)
            {
                // check if movie needs adding to db and add view to counter
                movieService.AddToMoviesOrAddView(movie);
            }

            return View("ViewMovie", movie);
        }

        public ActionResult RateMovie(int movieApiID, int stars)
        {
            var userId = User.Identity.GetUserId();
                       
            movieService.RateMovie(movieApiID, stars, userId);
            
            return RedirectToAction("ViewMovieByID", new { movieApiId = movieApiID, addView = false} );
        }

    }
}