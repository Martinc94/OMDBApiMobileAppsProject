using OMDBApiMobileAppsProject.Data;
using OMDBApiMobileAppsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OMDBApiMobileAppsProject
{
    public sealed partial class SearchPage : Page
    {
        public static Boolean found;

        public SearchPage()
        {
            this.InitializeComponent();
            viewTitles = new SearchVM();
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            infoLbl.Text = "Searching...";

            string searchTitle = txbSearchTitle.Text.ToString();

            //Debug.WriteLine(searchTitle);

            found = await Search(searchTitle);

            if (found == false)
            {
                errorLbl.Text = "Movie Not Found";
            }
            else {
                errorLbl.Text = "";
            }

            // await System.Threading.Tasks.Task.Delay(1000);

            await viewTitles.Refresh();

            // viewTitles.Refresh();

            infoLbl.Text = "";
            searchTitle = "";
            txbSearchTitle.Text = "";

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //string searchTitle = txbSearchTitle.Text.ToString();
            Debug.WriteLine("SAVE");

        }


        private void s_Click(object sender, RoutedEventArgs e)
        {
            //string searchTitle = txbSearchTitle.Text.ToString();
            Debug.WriteLine("SAVE");
        }



        private async Task<Boolean> Search(string searchTitle) {
            return await SearchMovieService.GetMovieByTitle(searchTitle);
        }

        public SearchVM viewTitles { get; set; }

    }
}
