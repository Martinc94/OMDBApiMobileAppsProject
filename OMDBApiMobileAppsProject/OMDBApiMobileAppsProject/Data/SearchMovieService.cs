using System;
using System.Collections.Generic;
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
            Load();
        }

        public static async Task Load()
        {
            //await LoadLocalData();
            await GetMovieByTitle("Lethal Weapon");
        }

        public static async Task GetMovieByTitle(string searchTitle)
        {
            //http://www.omdbapi.com/?t=NAME+&y=YEAR&plot=short&r=json

            var client = new HttpClient();

            StringBuilder sb = new StringBuilder();

            sb.Append(urlString);

            //add check if null
            sb.Append(searchTitle);
            sb.Append("&plot=short&r=json");

            var uri = new Uri(sb.ToString());
            var response = await client.GetStringAsync(uri);

            Debug.WriteLine(response);

            var foundMovie = JsonObject.Parse(response);

            var movieArray = new JsonArray();

            movieArray.Add(foundMovie);

            CreateMovieList(movieArray);


        }

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
                //Debug.WriteLine(nMovie.title);
            } // end foreach 
        }//end createMovieList





    }
}
