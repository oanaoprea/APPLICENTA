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
            int ok = 1;
            List<User> users = await App.Database2.GetUserAsync();
            foreach (var i in users)
            {
                if (i.Username == username.Text)
                {
                    ok = 0;
                }
            }
            if (username.Text != null && password.Text != null && ok == 1)
            {
                var ulist = (User)BindingContext;
                await App.Database2.SaveUserAsync(ulist);
                await Navigation.PushAsync(new LoginPage());
                await DisplayAlert("Success", "You have been registered!", "OK");
            }
            else if (ok==0)
            {
                await DisplayAlert("Alert", "Username already used!", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Username and Password can't be empty!", "OK");
            }
        }
    }
}