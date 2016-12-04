using OMDBApiMobileAppsProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OMDBApiMobileAppsProject.ViewModels
{
    public class MovieViewModel : Helper.NotificationBase<Movie>
    {
        public MovieViewModel(Movie movie = null) : base(movie) { }
        public String Title
        {
            get { return This.Title; }
            set { SetProperty(This.Title, value, () => This.Title = value);}
        }
        public String Year
        {
            get { return This.Year; }
            set { SetProperty(This.Year, value, () => This.Year = value); }
        }

        public String Rated
        {
            get { return This.Rated; }
            set { SetProperty(This.Rated, value, () => This.Rated = value); }
        }

        public String Runtime
        {
            get { return This.Runtime; }
            set { SetProperty(This.Runtime, value, () => This.Runtime = value); }
        }

        public String Genre
        {
            get { return This.Genre; }
            set { SetProperty(This.Genre, value, () => This.Genre = value); }
        }

        public String Director
        {
            get { return This.Director; }
            set { SetProperty(This.Director, value, () => This.Director = value); }
        }

        public String Writer
        {
            get { return This.Writer; }
            set { SetProperty(This.Writer, value, () => This.Writer = value); }
        }
        public String Actors
        {
            get { return This.Actors; }
            set { SetProperty(This.Actors, value, () => This.Actors = value); }
        }
        public String Plot
        {
            get { return This.Plot; }
            set { SetProperty(This.Plot, value, () => This.Plot = value); }
        }
        public String Language
        {
            get { return This.Language; }
            set { SetProperty(This.Language, value, () => This.Language = value); }
        }
        public String Country
        {
            get { return This.Country; }
            set { SetProperty(This.Country, value, () => This.Country = value); }
        }
            public String Awards
        {
            get { return This.Awards; }
            set { SetProperty(This.Awards, value, () => This.Awards = value); }
        }
        public String Poster
        {
            get{
                string pos = This.Poster;
                //if adding new Movie poster will be null(null will cause error when binding)
                if (pos==""||pos==null) {
                    pos = " ";
                }
                return pos;
            }
            set { SetProperty(This.Poster, value, () => This.Poster = value); }
        }
        public String Metascore
        {
            get { return This.Metascore; }
            set { SetProperty(This.Metascore, value, () => This.Metascore = value); }
        }
        public String imdbRating
        {
            get { return This.imdbRating; }
            set { SetProperty(This.imdbRating, value, () => This.imdbRating = value); }
        }
    }
}
