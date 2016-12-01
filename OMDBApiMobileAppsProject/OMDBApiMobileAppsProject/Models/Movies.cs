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
            await LoadLocalData();
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
                        case "Released":
                            nMovie.released = value.GetString();
                            break;
                        case "Genre":
                            nMovie.genre = value.GetString();
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


