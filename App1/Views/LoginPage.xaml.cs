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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int ok = 0;
            List<User> ulist = await App.Database2.GetUserAsync();
            foreach (var i in ulist)
            { 
                if (i.Username == username.Text && i.Password == password.Text)
                    ok = 1;
            }

            if (username.Text == "admin")
            {
                var meal = (Shell.Current as AppShell).MealItem;
                meal.IsVisible = false;

                var workout = (Shell.Current as AppShell).WkItem;
                workout.IsVisible = false;

            }

            if (username.Text != "admin")
            {
                var mmeal = (Shell.Current as AppShell).MMealItem;
                mmeal.IsVisible = false;

                var mwk = (Shell.Current as AppShell).MWkItem;
                mwk.IsVisible = false;

                var muser = (Shell.Current as AppShell).MUserItem;
                muser.IsVisible = false;

            }

            if (ok == 1 && username.Text != null && password.Text != null && username.Text != "admin")
            {
                await Shell.Current.GoToAsync($"//{nameof(WorkoutsPage)}");
            }
            else if (ok == 1 && username.Text != null && password.Text != null && username.Text == "admin")
            {
                await Shell.Current.GoToAsync($"//{nameof(CRUDWorkouts)}");
            }
            else
            {
                await DisplayAlert("Alert", "Incorrect username or password!", "OK");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
    
        }
    }
}