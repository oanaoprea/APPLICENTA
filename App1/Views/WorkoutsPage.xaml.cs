using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            listView.ItemsSource = new ObservableCollection<Workout>(await App.Database1.GetWorkoutAsync());
            List<Workout> wlist = await App.Database1.GetWorkoutAsync();
            calories_burnt = 0;
            listView.SelectedItem = null;
            foreach (var i in wlist)
            {
                if (i.IsChecked == true)
                {
                    calories_burnt = calories_burnt + long.Parse(i.CaloriesBurnt);
                }
            }
            label_cal.Text = calories_burnt.ToString();
        }
        public long calories_burnt = 0;
        public bool ch;
        public WorkoutsPage()
        {
            InitializeComponent();
            //label_cal.Text = calories_burnt.ToString();
        }
        private void box1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ch = false;


            var workout = listView.SelectedItem as Workout;
            if (listView.SelectedItem != null)
            {
                if (e.Value == true)
                {
                    long cal = long.Parse(workout.CaloriesBurnt);
                    calories_burnt = calories_burnt + cal;
                    ch = true;
                }
                else
                {
                    long cal = long.Parse(workout.CaloriesBurnt);
                    calories_burnt = calories_burnt - cal;
                    ch = false;
                }

                workout.IsChecked = ch;
                App.Database1.SaveWorkoutAsync(workout);
                label_cal.Text = calories_burnt.ToString();
            }



        }


    }
}