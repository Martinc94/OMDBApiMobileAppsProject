using Newtonsoft.Json;
using OMDBApiMobileAppsProject.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

//using System.Web.Script.Serialization;

namespace OMDBApiMobileAppsProject.Models
{
    public class Movies
    {
        public static List<Movie> movieList = new List<Movie>();
        public List<Movie> Titles { get; set; }
        public string title { get; set; }

        public Movies()
        {
            Titles = movieList;
            init(Titles);
        }

        public static async Task init(List<Movie> Titles)
        {
            if (movieList.Count != 0)
            {
                // movieList.Clear();
                Debug.WriteLine("[movie list not empty]: " + movieList.Count);
                movieList = new List<Movie>();
                LoadData();
                Titles = movieList;
            }
            else
            {
                Debug.WriteLine("[Movie list is empty]: ");
                LoadData();
                Titles = movieList;
            }
        }

        public static async Task LoadData()
        {
            await LoadLocalMovies();  
        }

        public static async Task LoadLocalMovies()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile movieFile;

            //get movies
            movieFile = await storageFolder.CreateFileAsync("MyMovies.txt", CreationCollisionOption.OpenIfExists);
            string movieJson = await Windows.Storage.FileIO.ReadTextAsync(movieFile);

            var jMovieList = JsonArray.Parse(movieJson);
            CreateMovieList(jMovieList);
        }

        //adds JsonArray to a List of Movies
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

        public void Add(Movie movie)
        {
            if (!Titles.Contains(movie))
            {
                movie.Poster = "";
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

        public async void Save(Movie movie)
        {
     
        }//end add

        public async void SaveAll()
        {
            Debug.WriteLine("[IN SaveAll]: ");
            await saveMovies();
        }//end saveAll

        //saves Movies To Local Storage
        public async Task saveMovies()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile movieFile;

            //get movie file 
            movieFile = await storageFolder.CreateFileAsync("MyMovies.txt", CreationCollisionOption.OpenIfExists);
         
            string output;

            StringBuilder sb = new StringBuilder();
            //start of array
            sb.Append("[");

            int count = 0;
            foreach (var item in Titles)
            {
                if (count ==0) {
                    output = JsonConvert.SerializeObject(item);
                    sb.Append(output);

                }
                //, needed when not first in array
                else {
                    output = JsonConvert.SerializeObject(item);
                    sb.Append(","+output);
                }//end else

                count++;

            }//end foreach

            sb.Append("]");

            //Debug.WriteLine("[Serialized Object]: " + sb.ToString());

            //save to file 
            await FileIO.WriteTextAsync(movieFile, sb.ToString());  

        }//end saveMovies

    }//end saveMovies
}


