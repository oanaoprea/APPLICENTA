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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (username.Text != null && password.Text != null)
            {
                var ulist = (User)BindingContext;
                await App.Database2.SaveUserAsync(ulist);
                await Navigation.PushAsync(new LoginPage());
                await DisplayAlert("Success", "You have been registered!", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Username and Password can't be empty!", "OK");
            }
        }
    }
}