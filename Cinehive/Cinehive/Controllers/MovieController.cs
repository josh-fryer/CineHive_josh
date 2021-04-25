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

        [Authorize]
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

        [Authorize]
        public ActionResult ViewMore(int id, dynamic item)
        {
            if (id == 1)
            {
                var upcoming = movieService.PrepUpcomingMovies(item);
                var list = movieService.GetUpcomingMovies(upcoming);
                ViewBag.PageTitle = "Upcoming";

                return View(list);
            }
            else if (id == 2)
            {
                var popcritic = movieService.PrepCriticallyAcclaimed(item);
                var list = movieService.GetCriticallyAcclaimed(popcritic);
                ViewBag.PageTitle = "Critically Acclaimed";
                return View(list);
            }
            else if (id == 3)
            {
                var intheatres = movieService.PrepInTheatres(item);
                var list = movieService.GetInTheatres(intheatres);
                ViewBag.PageTitle = "Now In Theatres";
                return View(list);
            }
            else
            {
                return View();
            }

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
    
        public ActionResult ViewMovie(Movie movie, bool addView = true)
        {
            if (addView)
            {
                // check if movie needs adding to db and add view to counter
                movieService.AddToMoviesOrAddView(movie);
            }

            ViewBag.avgRating = movieService.GetAvgRating(movie.MovieApi_ID);
            ViewBag.userRating = movieService.GetUserRating(User.Identity.GetUserId(), movie.MovieApi_ID);
            return View(movie);
        }

        public ActionResult ViewMovieByID(int movieApiID, bool addView = true)
        {
            Movie movie = movieService.GetMovieByID(movieApiID);
            if (addView)
            {
                // check if movie needs adding to db and add view to counter
                movieService.AddToMoviesOrAddView(movie);
            }
            ViewBag.avgRating = movieService.GetAvgRating(movie.MovieApi_ID);
            ViewBag.userRating = movieService.GetUserRating(User.Identity.GetUserId(), movieApiID);
            return View("ViewMovie", movie);
        }

        // called by JS on movie page
        public void RateMovie(int movieApiID, int stars)
        {
            var userId = User.Identity.GetUserId();                      
            movieService.RateMovie(movieApiID, stars, userId);
        }
        
        public ActionResult TrendingMovies()
        {
            return View(movieService.Trending().Take(10));
        }

        public ActionResult TopRatedMovies()
        {
            ViewData["top10"] = movieService.TopRated();
            return View();
        }
    }
}