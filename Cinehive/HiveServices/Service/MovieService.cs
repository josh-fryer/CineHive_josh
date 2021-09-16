using HiveData.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HiveData.Repository;
using System.Web.Services;
using System.Data.Entity.Migrations;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Web.Hosting;

namespace HiveServices.Service
{
    public class MovieService : IMovieService
    {
        // Get Api key from ApiKey.txt file in "Cinehive\Content" folder:
        string key = File.ReadAllText(HostingEnvironment.ApplicationPhysicalPath + @"Content\ApiKey.txt");
        Uri baseAddress = new Uri("https://api.themoviedb.org/3/");
        HttpClient client;

        CineHiveContext context = new CineHiveContext();

        public MovieService()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public Movie LatestMovie(Movie movie)
        {
            HttpResponseMessage response =
            client.GetAsync(client.BaseAddress + "movie/" + "latest" + "?api_key=" + key + "&language=en-US&adult=false").Result;


            string data = response.Content.ReadAsStringAsync().Result;

            dynamic item = JsonConvert.DeserializeObject<dynamic>(data);

            movie = ConvertToMovie(item);

            return movie;
        }

        // Gets first result from a movies search
        public Movie ViewMovie(dynamic i)
        {
            if (i == null || i.total_results == 0) // if null
            {
                return new Movie(); // display empty
            }
            else
            {
                // returns first result from api's search results
                Movie movie = ConvertToMovie(i.results[0]);
                // Get videos for movie:
                HttpResponseMessage response =
                client.GetAsync(client.BaseAddress + "movie/" + movie.MovieApi_ID + "/videos?api_key="
                + key + "&language=en-US").Result;
                if (!response.IsSuccessStatusCode)
                {
                    return movie;
                }
                else
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    dynamic item = JsonConvert.DeserializeObject<dynamic>(data);
                    if (item.results.Count > 0) // if theres results
                    {
                        for (int j = 0; j < item.results.Count; j++) // loop through all returned videos to find type I want.
                        {
                            if (item.results[j].type == "Trailer" && item.results[j].site == "YouTube")
                            {
                                movie.VideoKey = item.results[j].key;
                                break;
                            }
                        }
                    }
                }
                return movie;
            }
        }

        // Make sure query is prepared first outside
        public dynamic SearchMovie(string q, int? page = 1, int? year = 0)
        {
            // example: "https://api.themoviedb.org/3/search/movie?api_key={api_key}&query=Jack+Reacher"
            string request = client.BaseAddress + "search/movie?api_key=" + key + "&query=" + q + "&page=" + page;
            if(year > 0) // have year
            {
                request = request + "&year=" + year.ToString();
            }

            HttpResponseMessage response = client.GetAsync(request).Result;
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

        public Movie GetMovieByID(int id)
        {
            // example: "https://api.themoviedb.org/3/movie/{movie_id}?api_key=<<api_key>>&language=en-US"
            HttpResponseMessage response =
                client.GetAsync(client.BaseAddress + "movie/" + id + "?api_key=" + key + "&language=en-US"+ "&append_to_response=videos").Result;
            if (!response.IsSuccessStatusCode) // call not successful
            {
                return null; // display nothing
            }
            else
            {
                string data = response.Content.ReadAsStringAsync().Result;
                // Deserialise JSON string into dynamic object
                dynamic item = JsonConvert.DeserializeObject<dynamic>(data);

                return ConvertToMovie(item); // returns array of search results
            }
        }

        // When searching from search bar:
        public async Task<dynamic> SearchMoviesAsync(string q)
        {
            string query = q.Trim();
            // example: "https://api.themoviedb.org/3/search/movie?api_key={api_key}&query=Jack+Reacher"
            HttpResponseMessage response =
                client.GetAsync(client.BaseAddress + "search/movie?api_key=" + key + "&query=" + query).Result;
            if (!response.IsSuccessStatusCode) // call not successful
            {
                return null; // display nothing
            }
            else
            {
                string data = response.Content.ReadAsStringAsync().Result;
                // Deserialise JSON string into dynamic object
                dynamic item = JsonConvert.DeserializeObject<dynamic>(data);

                if (item.results.Count > 0)
                {
                    // converts to Movie type
                    //return await ToMoviesListAsync(item);
                    return item;
                }

                return null; // No results, so display nothing
            }
        }

        public async Task<List<Movie>> ToMoviesListAsync(dynamic item, int? x)
        {
            if(item == null) { return null; }
            List<Movie> movies = new List<Movie>();
            // to make sure for loop iterates through fully Task.Run
            await Task.Run(() =>
            {
                for (int i = 0; i < x && i < item.results.Count; i++)
                {
                    movies.Add(ConvertToMovie(item.results[i]));
                }
            });

            return movies;
        }

        public Movie ConvertToMovie(dynamic item)
        {
            Movie movie = new Movie()
            {
                MovieApi_ID = item.id,
                PosterPath = item.poster_path,
                Overview = item.overview,
                Title = item.title,
            };

            if (item.release_date != "") // to check for unknown release dates
            {
                movie.ReleaseDate = item.release_date;
            }

            if (item.videos != null) // if theres video results
            {
                for (int i = 0; i < item.videos.results.Count; i++) // loop through videos array to find type I want.
                {
                    if (item.videos.results[i].type == "Trailer" && item.videos.results[i].site == "YouTube")
                    {
                        movie.VideoKey = item.videos.results[i].key;
                        break;
                    }
                }
            }
            return movie;
        }

        public dynamic PrepUpcomingMovies(dynamic item)
        {
            HttpResponseMessage response =
            client.GetAsync(client.BaseAddress + "movie/" + "upcoming" + "?api_key=" + key + "&language=en-US" + "&page=1").Result;

            string data = response.Content.ReadAsStringAsync().Result;

            item = JsonConvert.DeserializeObject<dynamic>(data);

            return item;
        }

        public List<Movie> GetUpcomingMovies(dynamic item)
        {
            List<Movie> movies = new List<Movie>();

            for (int i = 0; i < item.results.Count; i++)
            {
                movies.Add(ConvertToMovie(item.results[i]));
            }

            return movies;
        }

        public dynamic PrepCriticallyAcclaimed(dynamic item)
        {
            HttpResponseMessage response =
            client.GetAsync(client.BaseAddress + "movie/" + "top_rated" + "?api_key=" + key + "&language=en-US" + "&page=1").Result;

            string data = response.Content.ReadAsStringAsync().Result;

            item = JsonConvert.DeserializeObject<dynamic>(data);

            return item;
        }

        public List<Movie> GetCriticallyAcclaimed(dynamic item)
        {
            List<Movie> movies = new List<Movie>();

            for (int i = 0; i < item.results.Count; i++)
            {
                movies.Add(ConvertToMovie(item.results[i]));
            }

            return movies;
        }

        public dynamic PrepInTheatres(dynamic item)
        {
            HttpResponseMessage response =
            client.GetAsync(client.BaseAddress + "movie/" + "now_playing" + "?api_key=" + key + "&language=en-US" + "&page=1").Result;

            string data = response.Content.ReadAsStringAsync().Result;

            item = JsonConvert.DeserializeObject<dynamic>(data);

            return item;
        }

        public List<Movie> GetInTheatres(dynamic item)
        {
            List<Movie> movies = new List<Movie>();

            for (int i = 0; i < item.results.Count; i++)
            {
                movies.Add(ConvertToMovie(item.results[i]));
            }

            return movies;
        }

        // check if movie is in database. If not then add to database. and add 1 to view counter.
        public void AddToMoviesOrAddView(Movie movie)
        {
            using (var context = new CineHiveContext())
            {
                bool movieExists = context.Movies.Where(m => m.MovieApi_ID == movie.MovieApi_ID).Any();
                if (movieExists)
                {
                    // add to existing film in db
                    var CurrentMovie = context.Movies.First(m => m.MovieApi_ID == movie.MovieApi_ID);
                    CurrentMovie.ViewCounter++;
                    if (CurrentMovie.ViewCounter > 20)
                    {
                        CurrentMovie.Trending = true;
                    }
                }
                else
                {
                    movie.ViewCounter += 1;
                    context.Movies.Add(movie);
                }
                context.SaveChanges();
            }
        }

        public void RateMovie(int movieApiID, int stars, string userId)
        {
            using (var context = new CineHiveContext())
            {
                UserProfile user = context.UserProfiles.First(x => x.UserId == userId);
                bool foundRating = false;
                // get movie
                var movie = context.Movies.First(m => m.MovieApi_ID == movieApiID);

                foreach (var rating in user.Ratings)
                {
                    if (movie.Ratings.Contains(rating))
                    {
                        // set rating
                        rating.Stars = stars;
                        rating.Date = DateTime.Now;
                        foundRating = true;
                        break;
                    }
                }

                // no rating for this movie from user exists.
                if (!foundRating)
                {
                    // add new rating to collections of movie and user
                    Rating newRating = new Rating()
                    {
                        Stars = stars,
                        Date = DateTime.Now
                    };
                    user.Ratings.Add(newRating);
                    movie.Ratings.Add(newRating);
                }

                context.SaveChanges();
            }         
        }

        public int GetAvgRating(int movieApiID)
        {
            using (var context = new CineHiveContext())
            {
                int avg = 0;
                bool movieExists = context.Movies.Where(m => m.MovieApi_ID == movieApiID).Any();
                if (!movieExists)
                {
                    return avg;
                }
                var ratingsList = context.Movies.Where(m => m.MovieApi_ID == movieApiID).First().Ratings.ToList();

                if (ratingsList.Count >= 1) // has ratings
                {
                    int total = 0;
                    foreach (var rating in ratingsList)
                    {
                        total += rating.Stars;
                    }

                    double avgResult = (double)total / (double)ratingsList.Count;
                    avg = (int)Math.Round(avgResult, 0);
                }

                return avg;
            }
        }

        public int GetUserRating(string userID, int movieApiID)
        {
            using (var context = new CineHiveContext())
            {
                var user = context.UserProfiles.First(p => p.UserId == userID);
                var movie = context.Movies.First(m => m.MovieApi_ID == movieApiID);

                if (user.Ratings.Intersect(movie.Ratings).Any())
                {
                    // user can only have one rating for a movie
                    return user.Ratings.Intersect(movie.Ratings).First().Stars;
                }
                else
                {
                    return 0;
                }
                 
            }     
        }

        public void GetGenresToDb()
        {
            using (var context = new CineHiveContext())
            {
                //1. get api genres
                // example: "https://api.themoviedb.org/3/genre/movie/list?api_key=<<api_key>>&language=en-US"
                HttpResponseMessage response =
                client.GetAsync(client.BaseAddress + "genre/movie/list" + "?api_key=" + key + "&language=en-US").Result;
                if (response.IsSuccessStatusCode) // call not successful
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    // Deserialise JSON string into dynamic object
                    dynamic item = JsonConvert.DeserializeObject<dynamic>(data);

                    // convert to genre model and add to database
                    for (int i = 0; i < item.genres.Count; i++)
                    {
                        // filter out specific genres
                        if (item.genres[i].name == "TV Movie")
                        {
                            continue;
                        }
                        Genre g = ConvertToGenre(item.genres[i]);
                        context.Genres.AddOrUpdate(g);
                    }
                    context.SaveChanges();
                }
            }
        }

        public Genre ConvertToGenre(dynamic x)
        {
            Genre genre = new Genre()
            {
                ApiId = x.id,
                Name = x.name
            };

            return genre;
        }

        public IList<Movie> Trending()
        {
            return context.Movies.Where(c => c.Trending == true).ToList();
        }

        // find top 10 highest rated films by cinehive users
        public IEnumerable<KeyValuePair<Movie, int>> TopRated()
        {
            using(var context = new CineHiveContext())
            {
                var movies = context.Movies.Where(m => m.Ratings.Count >= 1).ToList();            
                // Dictionary<movieID, total stars for movie>
                IDictionary<Movie, int> movieStarsSum = new Dictionary<Movie, int>(); 

                foreach (var m in movies)
                {
                   int avgRating = GetAvgRating(m.MovieApi_ID);
                   movieStarsSum.Add(m, avgRating);
                }

                var top10 = movieStarsSum.OrderByDescending(i => i.Value).Take(10);

                return top10;
            }    
        }

    }
}
