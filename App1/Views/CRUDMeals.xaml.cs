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
    public partial class CRUDMeals : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = new ObservableCollection<Meal>(await App.Database.GetMealAsync());
            List<Meal> mlist = await App.Database.GetMealAsync();
        }
        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealListPage
            {
                BindingContext = new Meal()
            });
        }
        async void EditClicked(object sender, EventArgs e)
        {
            var meal = listView.SelectedItem;
            if (meal != null)
            {
                await Navigation.PushAsync(new MealListPage
                {
                    BindingContext = meal as Meal
                });
            }
        }
        async void DeleteClicked(object sender, EventArgs e)
        {
            var meal = listView.SelectedItem as Meal;
            if (meal != null)
            {
                await App.Database.DeleteMealAsync(meal);
            }    
        }
        public CRUDMeals()
            {
                InitializeComponent();
            }
        private async void listView_Refreshing(object sender, EventArgs e)
        {
            listView.IsRefreshing = true;
            await Task.Delay(2000);
            listView.ItemsSource = await App.Database.GetMealAsync();
            listView.IsRefreshing = false;
        }
    }
}