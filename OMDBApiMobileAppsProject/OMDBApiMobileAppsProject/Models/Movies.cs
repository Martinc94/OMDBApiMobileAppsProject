using OMDBApiMobileAppsProject.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace OMDBApiMobileAppsProject.Models
{
    public class Movies
    {
        public static List<Movie> movieList = new List<Movie>();
        public List<Movie> Titles { get; set; }
        public string title { get; set; }

        public Movies()
        {
            LoadData();
            Titles = movieList;
        }

        public static async Task LoadData()
        {
            //await LoadLocalData();
            await LoadLocalMovies(); 
        }

        public static async Task LoadLocalData()
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\myMovies.txt");
            var result = await FileIO.ReadTextAsync(file);

            var jMovieList = JsonArray.Parse(result);
            CreateMovieList(jMovieList);

            //output to console
            //System.Diagnostics.Debug.Write(jMovieList.ToString());
        }

        public static async Task LoadLocalMovies()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile movieFile;

            //get movies
            // movieFile = await storageFolder.GetFileAsync("myMovies.txt");
            movieFile = await storageFolder.CreateFileAsync("MyMovies.txt", CreationCollisionOption.OpenIfExists);

            System.Diagnostics.Debug.WriteLine(Windows.Storage.ApplicationData.Current.LocalFolder.Path);

            string movieJson = await Windows.Storage.FileIO.ReadTextAsync(movieFile);

            var jMovieList = JsonArray.Parse(movieJson);
            CreateMovieList(jMovieList);
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
            } // end foreach 
        }//end createMovieList

        public void Add(Movie movie)
        {
            if (!Titles.Contains(movie))
            {
                movie.poster = "";
                Titles.Add(movie);
                //FakeService.Write(movie);
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

}//end Movies
}


