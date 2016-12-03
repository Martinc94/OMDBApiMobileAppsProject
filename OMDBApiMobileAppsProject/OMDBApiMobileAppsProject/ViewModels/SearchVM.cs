﻿using OMDBApiMobileAppsProject.Data;
using OMDBApiMobileAppsProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDBApiMobileAppsProject.ViewModels
{
    public class SearchVM : Helper.NotificationBase
    {
        SearchMovieService myMovie;

        public SearchVM()
        {
            myMovie = new SearchMovieService();
            _SelectedIndex = -1;
            // Load the database
            foreach (var myMovie in myMovie.Titles)
            {
                var np = new MovieViewModel(myMovie);
                np.PropertyChanged += Movie_OnNotifyPropertyChanged;
                // System.Diagnostics.Debug.WriteLine(np.released.ToString());
                _Mov.Add(np);
            }
        }

        ObservableCollection<MovieViewModel> _Mov = new ObservableCollection<MovieViewModel>();

        public ObservableCollection<MovieViewModel> Titles
        {
            get { return _Mov; }
            set { SetProperty(ref _Mov, value); }
        }

        //String _MovieTitle;
        public String MovieTitle
        {
            get { return myMovie.title; }
        }

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedMovie)); }
            }
        }

        public MovieViewModel SelectedMovie
        {
            get { return (_SelectedIndex >= 0) ? _Mov[_SelectedIndex] : null; }
        }

        public void Add()
        {
            var nMovie = new MovieViewModel();
            nMovie.PropertyChanged += Movie_OnNotifyPropertyChanged;
            Titles.Add(nMovie);
            //myMovie.Add(nMovie);
            SelectedIndex = Titles.IndexOf(nMovie);
        }

        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var mov = Titles[SelectedIndex];
                Titles.RemoveAt(SelectedIndex);
                // myMovie.Delete(person);
            }
        }

        public void Save()
        {
            if (SelectedIndex != -1)
            {
                var mov = Titles[SelectedIndex];
                //Titles.RemoveAt(SelectedIndex);
                // myMovie.Delete(person);
                Debug.WriteLine("Save to local");
                Debug.WriteLine(mov.Title);

            }
        }

        void Movie_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
             myMovie.Update((MovieViewModel)sender);
        }


        public async Task Refresh()
        {
            //Debug.WriteLine("[REFRESH]");
            //notify view 
            foreach (var myMovie in myMovie.Titles)
             {
                 var np = new MovieViewModel(myMovie);
                 np.PropertyChanged += Movie_OnNotifyPropertyChanged;
                 Titles.Clear();
                 Titles.Add(np); 
            }

        }//end refresh

        public void SaveNew() {
            if (SelectedIndex != -1)
            {
                var mov = Titles[SelectedIndex];
                //Titles.RemoveAt(SelectedIndex);
                // myMovie.Delete(person);
                Debug.WriteLine("Save to local");
                Debug.WriteLine(mov.Title);

            }
        }


    }
}
