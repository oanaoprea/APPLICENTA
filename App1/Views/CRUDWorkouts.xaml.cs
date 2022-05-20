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
    public partial class CRUDWorkouts : ContentPage
    {

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database1.GetWorkoutAsync();
        }
        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutListPage
            {
                BindingContext = new Workout()
            });
        }

        async void EditClicked(object sender, EventArgs e)
        {
            var workout = listView.SelectedItem;
            if (workout != null)
            {
                await Navigation.PushAsync(new WorkoutListPage
                {
                    BindingContext = workout as Workout
                });
            }
        }


        async void DeleteClicked(object sender, EventArgs e)
        {
            var workout = listView.SelectedItem as Workout;
            if (workout != null)
            {
                await App.Database1.DeleteWorkoutAsync(workout);
            }

        }

        public CRUDWorkouts()
        {
            InitializeComponent();
        }

        private async void listView_Refreshing(object sender, EventArgs e)
        {
            listView.IsRefreshing = true;
            await Task.Delay(2000);
            listView.ItemsSource = await App.Database1.GetWorkoutAsync();
            listView.IsRefreshing = false;
        }
    }
}