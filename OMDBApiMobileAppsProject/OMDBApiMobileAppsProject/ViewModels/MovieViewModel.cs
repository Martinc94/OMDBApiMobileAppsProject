using OMDBApiMobileAppsProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
            set { SetProperty(This.title, value, () => This.title = value); }
        }
        public String Year
        {
            get { return This.year; }
            set { SetProperty(This.year, value, () => This.year = value); }
        }

        public String Activity
        {
            get { return This.activity; }
            set { SetProperty(This.activity, value, () => This.activity = value); }
        }

        public String Rated
        {
            get { return This.rated; }
            set { SetProperty(This.rated, value, () => This.rated = value); }
        }

        public String released
        {
            get { return This.released; }
            set { SetProperty(This.released, value, () => This.released = value); }
        }
    }
}
