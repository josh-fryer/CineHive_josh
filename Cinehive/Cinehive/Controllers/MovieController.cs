using HiveData.Models;
using HiveServices.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Cinehive.Controllers
{
    public class MovieController : Controller
    {
        /* ################### Api links ####################
        https://developers.themoviedb.org/3/getting-started/introduction
        For list of poster and other image sizes:
        https://developers.themoviedb.org/3/configuration/get-api-configuration
        #####################################################*/

        private MovieService movieService;

        public MovieController()
        {
            movieService = new MovieService();
        }

        // search for movie title then return view of movie details
        public ActionResult GetPostMovie(string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                return View();
            }

            string prepQuery = movieService.PreparePostQuery(query);
            var movies = movieService.SearchMovie(prepQuery);
            var movie = movieService.ViewMovie(movies);

            return RedirectToAction("ViewMovie", movie);        
        }

        public ActionResult GetMovieByID(int id)
        {
            Movie movie = movieService.GetMovieByID(id);
            return RedirectToAction("ViewMovie", movie);
        }

        public ActionResult ViewMovie(Movie movie)
        {
            return View(movie);
        }

    }
}