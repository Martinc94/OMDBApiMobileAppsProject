using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace OMDBApiMobileAppsProject.Data
{
    class fakeService
    {
        public static List<Movie> movieList = new List<Movie>();

        public static async Task LoadLocalData()
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\myMovies.txt");
            var result = await FileIO.ReadTextAsync(file);

            var jMovieList = JsonArray.Parse(result);
            CreateMovieList(jMovieList);
        }

        public static void CreateMovieList(JsonArray jMovieList)
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
                        case "title":
                            nMovie.title = value.GetString();
                            break;
                        case "year":
                            nMovie.year = value.GetString();
                            break;
                        case "rated":
                            nMovie.rated = value.GetString();
                            break;
                        case "released":
                            nMovie.released = value.GetString();
                            break;
                        case "genre":
                            nMovie.genre = value.GetString();
                            break;
                    } // end switch
                } // end foreach(var key in oneMovie.Keys )
                //Debug.WriteLine("Title: "+nMovie.title);
                movieList.Add(nMovie);
            } // end foreach (var item in jMovieList)

        }

    }
}
