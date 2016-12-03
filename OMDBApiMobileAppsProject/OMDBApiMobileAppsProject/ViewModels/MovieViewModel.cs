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
            get { return This.title; }
            set { SetProperty(This.title, value, () => This.title = value);}
        }
        public String Year
        {
            get { return This.year; }
            set { SetProperty(This.year, value, () => This.year = value); }
        }

        public String Rated
        {
            get { return This.rated; }
            set { SetProperty(This.rated, value, () => This.rated = value); }
        }

        public String Runtime
        {
            get { return This.runtime; }
            set { SetProperty(This.runtime, value, () => This.runtime = value); }
        }

        public String Genre
        {
            get { return This.genre; }
            set { SetProperty(This.genre, value, () => This.genre = value); }
        }

        public String Director
        {
            get { return This.director; }
            set { SetProperty(This.director, value, () => This.director = value); }
        }

        public String Writer
        {
            get { return This.writer; }
            set { SetProperty(This.writer, value, () => This.writer = value); }
        }
        public String Actors
        {
            get { return This.actors; }
            set { SetProperty(This.actors, value, () => This.actors = value); }
        }
        public String Plot
        {
            get { return This.plot; }
            set { SetProperty(This.plot, value, () => This.plot = value); }
        }
        public String Language
        {
            get { return This.language; }
            set { SetProperty(This.language, value, () => This.language = value); }
        }
        public String Country
        {
            get { return This.country; }
            set { SetProperty(This.country, value, () => This.country = value); }
        }
            public String Awards
        {
            get { return This.awards; }
            set { SetProperty(This.awards, value, () => This.awards = value); }
        }
        public String Poster
        {
            get{
                string pos = This.poster;
                //if adding new Movie poster will be null(null will cause error when binding)
                if (pos==""||pos==null) {
                    pos = " ";
                }
                return pos;
            }
            set { SetProperty(This.poster, value, () => This.poster = value); }
        }
        public String Metascore
        {
            get { return This.metascore; }
            set { SetProperty(This.metascore, value, () => This.metascore = value); }
        }
        public String imdbRating
        {
            get { return This.imdbRating; }
            set { SetProperty(This.imdbRating, value, () => This.imdbRating = value); }
        }
    }
}
