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
    public partial class WorkoutsPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database1.GetWorkoutAsync();
        }
        public long calories_burnt = 0;
        public WorkoutsPage()
        {
            InitializeComponent();
            label_cal.Text = calories_burnt.ToString();
        }
        private void box1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var workout = listView.SelectedItem as Workout;
            if (listView.SelectedItem != null)
            {
                if (e.Value == true)
                {
                    long cal = long.Parse(workout.CaloriesBurnt);
                    calories_burnt = calories_burnt + cal;
                }
                else
                {
                    long cal = long.Parse(workout.CaloriesBurnt);
                    calories_burnt = calories_burnt - cal;
                }
            }
            label_cal.Text = calories_burnt.ToString();
        }

        
    }
}