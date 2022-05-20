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
    public partial class MealListPage : ContentPage
    {
        public MealListPage()
        {
            InitializeComponent();
        }



        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var mlist = (Meal)BindingContext;
            await App.Database.SaveMealAsync(mlist);
            await Navigation.PopAsync();
        }
    }
}