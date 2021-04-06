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

        // view movie details page
        public ActionResult SearchViewMovie(string query)
        {
            if (query == null)
            {
                return View();
            }
            var movies = movieService.SearchMovie(query);
            var movie = movieService.ViewMovie(movies);
            if(movie == null)
            {
                return View();
            }
            return View(movie);        
        }

        public ActionResult ViewMovieByID(int id)
        {
            return View();
        }

    }
}