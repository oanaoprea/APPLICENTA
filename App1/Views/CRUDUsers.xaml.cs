using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDUsers : ContentPage
    {

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database2.GetUserAsync();
        }


        public CRUDUsers()
        {
            InitializeComponent();
        }

        private async void listView_Refreshing(object sender, EventArgs e)
        {
            listView.IsRefreshing = true;
            await Task.Delay(2000);
            listView.ItemsSource = await App.Database2.GetUserAsync();
            listView.IsRefreshing = false;
        }


       

        async void DeleteClicked(object sender, EventArgs e)
        {
            var user = listView.SelectedItem as User;
            if (user != null)
            {
                await App.Database2.DeleteUserAsync(user);
            }

        }

    }
}