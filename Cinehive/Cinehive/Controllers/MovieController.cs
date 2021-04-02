using HiveData.Models;
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

        string key = "f843620fb54518820f6b817e854c9ce3";
        Uri baseAddress = new Uri("https://api.themoviedb.org/3/");
        HttpClient client;

        public MovieController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // view movie details page
        public ActionResult ViewMovie(string query)
        {
            if (query == null)
            {
                return View();
            }
            string q = PrepareQuery(query);
            dynamic i = SearchMovie(q);
            if(i == null || i.total_results == 0 ) // if null
            {
                return View(); // display empty
            }
            else
            {
                // returns first result from api's search results
                Movie movie = ConvertToMovie(i.results[0]);
                // Get videos for movie:
                HttpResponseMessage response =
                client.GetAsync(client.BaseAddress + "movie/"+ movie.ID + "/videos?api_key="
                + key+ "&language=en-US").Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View(movie);
                }
                else
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    dynamic item = JsonConvert.DeserializeObject<dynamic>(data);
                    if(item.results.Count > 0) // if theres results 
                    {
                        for (int j = 0; j < item.results.Count; j++) // loop through all returned videos to find type i want.
                        {
                            if (item.results[j].type == "Trailer" && item.results[j].site == "YouTube")
                            {
                                ViewBag.vidKey = item.results[0].key;
                                break;
                            }
                        }                        
                    }                                                      
                }
                return View(movie);
            }          
        }

        dynamic SearchMovie(string query)
        {
            // example: "https://api.themoviedb.org/3/search/movie?api_key={api_key}&query=Jack+Reacher"
            HttpResponseMessage response =
                client.GetAsync(client.BaseAddress + "search/movie?api_key="+key+"&query="+query).Result;
            if (!response.IsSuccessStatusCode) // call not successful
            {               
                return null; // display nothing
            }
            else
            {
                string data = response.Content.ReadAsStringAsync().Result;
                // Deserialise JSON string into dynamic object
                dynamic item = JsonConvert.DeserializeObject<dynamic>(data);

                return item; // returns array of search results
            }
        }

        private string PrepareQuery(string query)
        {
            // prepare search query for api
            string input = query.Trim();
            string newQ = "";
            foreach (char c in input)
            {
                if (c == ' ')
                {
                    newQ += '+';
                }
                else
                {
                    newQ += c;
                }
            }
            return newQ;
        }

        Movie ConvertToMovie(dynamic item)
        {
            Movie movie = new Movie()
            {
                ID = item.id,
                PosterPath = item.poster_path,
                Overview = item.overview,
                Title = item.title,
                ReleaseDate = item.release_date              
            };
            return movie;
        }

    }
}