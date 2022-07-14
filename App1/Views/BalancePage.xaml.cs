using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BalancePage : ContentPage
    {
        public BalancePage()
        {
            InitializeComponent();
        }

        public int kcalconsumed = 0;
        public int kcalburnt = 0;
        protected override async void OnAppearing()
        {
            if (insert.Text != null)
            {
                kcal.Text = insert.Text;
            }
            kcalconsumed = 0;
            List<Meal> mlist = await App.Database.GetMealAsync();
            foreach (var i in mlist)
            {
                if (i.IsChecked == true)
                {
                    kcalconsumed = kcalconsumed + int.Parse(i.Calories);
                }
            }

            consumed.Text = kcalconsumed.ToString();

            kcalburnt = 0;
            List<Workout> wlist = await App.Database1.GetWorkoutAsync();
            foreach (var j in wlist)
            {
                if (j.IsChecked == true)
                {
                    kcalburnt = kcalburnt + int.Parse(j.CaloriesBurnt);
                }
            }

            burnt.Text = kcalburnt.ToString();
            
            total.Text = (int.Parse(kcal.Text)-kcalconsumed+ kcalburnt).ToString();


            if (int.Parse(total.Text) < 0)
            {
                total.TextColor = ColorConverters.FromHex("#FF0000");
            }

            if (int.Parse(total.Text) > 0)
            {
                total.TextColor = ColorConverters.FromHex("#007F00");
            }
        }
        
        private void insert_Completed(object sender, EventArgs e)
        {
            if (insert.Text != null)
            {
                kcal.Text = insert.Text;
                total.Text = (int.Parse(kcal.Text) - kcalconsumed + kcalburnt).ToString();
            }

            if (int.Parse(total.Text)<0)
            {
                total.TextColor = ColorConverters.FromHex("#FF0000");
            }

            if (int.Parse(total.Text) > 0)
            {
                total.TextColor = ColorConverters.FromHex("#007F00");
            }

            if (insert.Text != null && int.Parse(insert.Text)<1200)
            {
                error.Text = "We recommend you to consider eating at least 1200 kcal!";
                error.IsVisible = true;
            }
            else
            {
                error.Text = "";
                error.IsVisible = false;
            }

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            total.Text = "0";
            burnt.Text = "0";
            consumed.Text = "0";
            insert.Text = null;
            kcal.Text = "0";
            insert.Placeholder = "Calories";
            List<Meal> mlist = await App.Database.GetMealAsync();
            
            foreach (var i in mlist)
            {
                if (i.IsChecked == true)
                {
                    i.IsChecked = false;
                }
                await App.Database.SaveMealAsync(i);
            }
            List<Workout> wlist = await App.Database1.GetWorkoutAsync();
            
            foreach (var j in wlist)
            {
                if (j.IsChecked == true)
                {
                    j.IsChecked = false;
                }
                await App.Database1.SaveWorkoutAsync(j);
            }
            
        }
    }
}