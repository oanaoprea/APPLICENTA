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
    public partial class MealsPage : ContentPage
    {

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMealAsync();
        }
        public long calories_consumed = 0;
        bool ch = false;
        
        public MealsPage()
        {
            InitializeComponent();
            label_cal.Text = calories_consumed.ToString();
            
            
        }

        


        private void box1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
            
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
            }
            label_cal.Text = calories_consumed.ToString();
        }

       
    }
}