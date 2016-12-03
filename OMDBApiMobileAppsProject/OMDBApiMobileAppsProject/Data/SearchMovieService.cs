using OMDBApiMobileAppsProject.Data;
using OMDBApiMobileAppsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace OMDBApiMobileAppsProject.Data
{
    class SearchMovieService
    {
        public static List<Movie> movieList = new List<Movie>();
        public List<Movie> Titles { get; set; }
        public string title { get; set; }

        public static string urlString = "http://www.omdbapi.com/?t=";

        public SearchMovieService()
        {
            Titles = movieList;
        }

        public static async Task<Boolean> GetMovieByTitle(string searchTitle)
        {

            Movie nMov = new Movie();
            var foundMovie = new JsonObject();
            var movieArray = new JsonArray();
            Boolean isValid;


            //http://www.omdbapi.com/?t=NAME+&y=YEAR&plot=short&r=json

            var client = new HttpClient();

            StringBuilder sb = new StringBuilder();

            sb.Append(urlString);

            //add check if null
            sb.Append(searchTitle);
            sb.Append("&plot=short&r=json");

            var uri = new Uri(sb.ToString());
            var response = await client.GetStringAsync(uri);

            Debug.WriteLine("[RESPONSE]: "+response);

            foundMovie = JsonObject.Parse(response);
            movieArray = new JsonArray();
            movieArray.Add(foundMovie);

            isValid =ParseResponse(movieArray);

            Debug.WriteLine("[isValid]: " + isValid);

            if (isValid) {
                addJsonToView(movieArray);
                return true;
            }

            else {
                //no movie found
                return false;

            }

        }

       /* public static async Task search(string searchTitle)
        {
            if (searchTitle!="") {
                await GetMovieByTitle(searchTitle);
            }
            
        }*/

        private static void addJsonToView(JsonArray jMovieList) {

            foreach (var item in jMovieList)
            {
                var oneMovie = item.GetObject();
                Movie nMovie = new Movie();

                

                foreach (var key in oneMovie.Keys)
                {
                    IJsonValue value;
                    if (!oneMovie.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "Title":
                            nMovie.title = value.GetString();
                            break;
                        case "Year":
                            nMovie.year = value.GetString();
                            break;
                        case "Rated":
                            nMovie.rated = value.GetString();
                            break;
                        case "Runtime":
                            nMovie.runtime = value.GetString();
                            break;
                        case "Genre":
                            nMovie.genre = value.GetString();
                            break;
                        case "Director":
                            nMovie.director = value.GetString();
                            break;
                        case "Writer":
                            nMovie.writer = value.GetString();
                            break;
                        case "Actors":
                            nMovie.actors = value.GetString();
                            break;
                        case "Plot":
                            nMovie.plot = value.GetString();
                            break;
                        case "Language":
                            nMovie.language = value.GetString();
                            break;
                        case "Country":
                            nMovie.country = value.GetString();
                            break;
                        case "Awards":
                            nMovie.awards = value.GetString();
                            break;
                        case "Poster":
                            nMovie.poster = value.GetString();
                            break;
                        case "Metascore":
                            nMovie.metascore = value.GetString();
                            break;
                        case "imdbRating":
                            nMovie.imdbRating = value.GetString();
                            break;
                    } // end switch

                } // end foreach(var key in oneMovie.Keys )

                movieList.Add(nMovie);

            } // end foreach 

        }//end addJsonToView

        private static void CreateMovieList(JsonArray jMovieList)
        {
            foreach (var item in jMovieList)
            {
                var oneMovie = item.GetObject();
                Movie nMovie = new Movie();

                foreach (var key in oneMovie.Keys)
                {
                    IJsonValue value;
                    if (!oneMovie.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "Title":
                            nMovie.title = value.GetString();
                            break;
                        case "Year":
                            nMovie.year = value.GetString();
                            break;
                        case "Rated":
                            nMovie.rated = value.GetString();
                            break;
                        case "Runtime":
                            nMovie.runtime = value.GetString();
                            break;
                        case "Genre":
                            nMovie.genre = value.GetString();
                            break;
                        case "Director":
                            nMovie.director = value.GetString();
                            break;
                        case "Writer":
                            nMovie.writer = value.GetString();
                            break;
                        case "Actors":
                            nMovie.actors = value.GetString();
                            break;
                        case "Plot":
                            nMovie.plot = value.GetString();
                            break;
                        case "Language":
                            nMovie.language = value.GetString();
                            break;
                        case "Country":
                            nMovie.country = value.GetString();
                            break;
                        case "Awards":
                            nMovie.awards = value.GetString();
                            break;
                        case "Poster":
                            nMovie.poster = value.GetString();
                            break;
                        case "Metascore":
                            nMovie.metascore = value.GetString();
                            break;
                        case "imdbRating":
                            nMovie.imdbRating = value.GetString();
                            break;
                    } // end switch
                } // end foreach(var key in oneMovie.Keys )
                movieList.Add(nMovie);
                Debug.WriteLine(nMovie.title);
            } // end foreach 
        }//end createMovieList

        private static Boolean ParseResponse(JsonArray jMovieList)
        {
            Boolean isValid = false;

            foreach (var item in jMovieList)
            {
                var oneMovie = item.GetObject();
 
                foreach (var key in oneMovie.Keys)
                {
                    IJsonValue value;
                    if (!oneMovie.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {    
                        case "Response":   
                            if (value.GetString()== "True") {
                                isValid = true;
                            }
                            else {
                                isValid = false;
                            }
                            break;
                    } // end switch
                } // end foreach(var key in oneMovie.Keys )  
            } // end foreach 
            return isValid;
        }//end parseResponse

        public void Add(Movie movie)
        {
            if (!Titles.Contains(movie))
            {
                //movie.poster = "";
                Titles.Add(movie);
                //FakeService.Write(movie);
                Debug.WriteLine("[IN ADD]: ");
            }
        }//end add

        public void Delete(Movie movie)
        {
            if (Titles.Contains(movie))
            {
                Titles.Remove(movie);
                //FakeService.Delete(movie);
            }
        }//end delete

        public void Update(Movie movie)
        {
            //FakeService.Write(movie);
            
        }//end update



    }
}
