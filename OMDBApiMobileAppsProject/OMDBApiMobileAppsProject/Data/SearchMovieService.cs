using Newtonsoft.Json;
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
using Windows.Storage;

namespace OMDBApiMobileAppsProject.Data
{
    class SearchMovieService
    {
        public static List<Movie> movieList = new List<Movie>();
        public List<Movie> Titles { get; set; }
        public string title { get; set; }

        public static List<Movie> movieListForSaving = new List<Movie>();
        public List<Movie> TitlesForSaving { get; set; }

        public static string urlString = "http://www.omdbapi.com/?t=";

        public SearchMovieService()
        {
            Titles = movieList;
        }

        //Gets movie From omdb Api
        public static async Task<Boolean> GetMovieByTitle(string searchTitle)
        {

            Movie nMov = new Movie();
            var foundMovie = new JsonObject();
            var movieArray = new JsonArray();
            Boolean isValid;

            var client = new HttpClient();

            StringBuilder sb = new StringBuilder();

            sb.Append(urlString);

            //add check if null
            sb.Append(searchTitle);
            sb.Append("&plot=short&r=json");

            var uri = new Uri(sb.ToString());
            var response = await client.GetStringAsync(uri);

            foundMovie = JsonObject.Parse(response);
            movieArray = new JsonArray();
            movieArray.Add(foundMovie);

            isValid =ParseResponse(movieArray);

            if (isValid) {
                addJsonToView(movieArray);
                return true;
            }
            else {
                //no movie found
                return false;
            }

        }//end getMovieByTitle

        //adds Json to List
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
                            nMovie.Title = value.GetString();
                            break;
                        case "Year":
                            nMovie.Year = value.GetString();
                            break;
                        case "Rated":
                            nMovie.Rated = value.GetString();
                            break;
                        case "Runtime":
                            nMovie.Runtime = value.GetString();
                            break;
                        case "Genre":
                            nMovie.Genre = value.GetString();
                            break;
                        case "Director":
                            nMovie.Director = value.GetString();
                            break;
                        case "Writer":
                            nMovie.Writer = value.GetString();
                            break;
                        case "Actors":
                            nMovie.Actors = value.GetString();
                            break;
                        case "Plot":
                            nMovie.Plot = value.GetString();
                            break;
                        case "Language":
                            nMovie.Language = value.GetString();
                            break;
                        case "Country":
                            nMovie.Country = value.GetString();
                            break;
                        case "Awards":
                            nMovie.Awards = value.GetString();
                            break;
                        case "Poster":
                            nMovie.Poster = value.GetString();
                            break;
                        case "Metascore":
                            nMovie.Metascore = value.GetString();
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
                            nMovie.Title = value.GetString();
                            break;
                        case "Year":
                            nMovie.Year = value.GetString();
                            break;
                        case "Rated":
                            nMovie.Rated = value.GetString();
                            break;
                        case "Runtime":
                            nMovie.Runtime = value.GetString();
                            break;
                        case "Genre":
                            nMovie.Genre = value.GetString();
                            break;
                        case "Director":
                            nMovie.Director = value.GetString();
                            break;
                        case "Writer":
                            nMovie.Writer = value.GetString();
                            break;
                        case "Actors":
                            nMovie.Actors = value.GetString();
                            break;
                        case "Plot":
                            nMovie.Plot = value.GetString();
                            break;
                        case "Language":
                            nMovie.Language = value.GetString();
                            break;
                        case "Country":
                            nMovie.Country = value.GetString();
                            break;
                        case "Awards":
                            nMovie.Awards = value.GetString();
                            break;
                        case "Poster":
                            nMovie.Poster = value.GetString();
                            break;
                        case "Metascore":
                            nMovie.Metascore = value.GetString();
                            break;
                        case "imdbRating":
                            nMovie.imdbRating = value.GetString();
                            break;
                    } // end switch
                } // end foreach(var key in oneMovie.Keys )
                movieList.Add(nMovie);
            } // end foreach 
        }//end createMovieList

        //returns a boolean if movie is Valid
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
                Titles.Add(movie);
            }
        }//end add

        public void Delete(Movie movie)
        {
            if (Titles.Contains(movie))
            {
                Titles.Remove(movie);
            }
        }//end delete

        public void Update(Movie movie)
        {
            
        }//end update

        //save movies to LocalStorage
        public async Task saveMovies()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile movieFile;

            //get movie file 
            movieFile = await storageFolder.CreateFileAsync("MyMovies.txt", CreationCollisionOption.OpenIfExists);
            string movieJson = await Windows.Storage.FileIO.ReadTextAsync(movieFile);

            if (movieJson!="") {
                var savedList = JsonArray.Parse(movieJson);

                //add new to array
                CreateMovieListForSaving(savedList);

            }//end If

            if (Titles.Count != 0)
            {
                //add new to array
                foreach (var item in Titles)
                {
                    movieListForSaving.Add(item);
                }

            }//end if

            TitlesForSaving = movieListForSaving;

            string output;

            StringBuilder sb = new StringBuilder();
            //start of array
            sb.Append("[");

            int count = 0;
            foreach (var item in TitlesForSaving)
            {
                if (count == 0)
                {
                    output = JsonConvert.SerializeObject(item);
                    sb.Append(output);

                }
                //, needed when not first in array
                else
                {
                    output = JsonConvert.SerializeObject(item);
                    sb.Append("," + output);
                }//end else

                count++;

            }//end foreach

            sb.Append("]");

            //Debug.WriteLine("[Serialized Object]: " + sb.ToString());

            //save to file 
            await FileIO.WriteTextAsync(movieFile, sb.ToString());  

        }//end saveMovies

        //Adds Movies to movieListForSaving List
        private static void CreateMovieListForSaving(JsonArray jMovieList)
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
                            nMovie.Title = value.GetString();
                            break;
                        case "Year":
                            nMovie.Year = value.GetString();
                            break;
                        case "Rated":
                            nMovie.Rated = value.GetString();
                            break;
                        case "Runtime":
                            nMovie.Runtime = value.GetString();
                            break;
                        case "Genre":
                            nMovie.Genre = value.GetString();
                            break;
                        case "Director":
                            nMovie.Director = value.GetString();
                            break;
                        case "Writer":
                            nMovie.Writer = value.GetString();
                            break;
                        case "Actors":
                            nMovie.Actors = value.GetString();
                            break;
                        case "Plot":
                            nMovie.Plot = value.GetString();
                            break;
                        case "Language":
                            nMovie.Language = value.GetString();
                            break;
                        case "Country":
                            nMovie.Country = value.GetString();
                            break;
                        case "Awards":
                            nMovie.Awards = value.GetString();
                            break;
                        case "Poster":
                            nMovie.Poster = value.GetString();
                            break;
                        case "Metascore":
                            nMovie.Metascore = value.GetString();
                            break;
                        case "imdbRating":
                            nMovie.imdbRating = value.GetString();
                            break;
                    } // end switch
                } // end foreach(var key in oneMovie.Keys )
                movieListForSaving.Add(nMovie);
            } // end foreach 
        }//end createMovieListForSaving
    }
}
