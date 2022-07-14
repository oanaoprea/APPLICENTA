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
    public partial class MealsPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            listView.ItemsSource = new ObservableCollection<Meal>(await App.Database.GetMealAsync());
            List<Meal> mlist = await App.Database.GetMealAsync();
            calories_consumed = 0;
            listView.SelectedItem = null;
            foreach (var i in mlist)
            {
                if (i.IsChecked == true)
                {
                    calories_consumed = calories_consumed + long.Parse(i.Calories);
                }
            }
                label_cal.Text = calories_consumed.ToString();

        }
        public bool ch;
        public long calories_consumed = 0;
       
        public MealsPage()
        {
            InitializeComponent();
        }
        private void box1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ch = false;
            var meal = listView.SelectedItem as Meal;
            if (listView.SelectedItem != null)
            {
                if (e.Value == true)
                {
                    long cal = long.Parse(meal.Calories);
                    calories_consumed = calories_consumed + cal;
                    ch = true;
                }
                else
                {
                    long cal = long.Parse(meal.Calories);
                    calories_consumed = calories_consumed - cal;
                    ch = false;
                }

                meal.IsChecked = ch;
                App.Database.SaveMealAsync(meal);
                label_cal.Text = calories_consumed.ToString();
            }
        }  
    }
}