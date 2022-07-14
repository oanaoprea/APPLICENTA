using System;
using Xamarin.Forms;

namespace App1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public ShellItem MealItem;
        public ShellItem MMealItem;
        public ShellItem WkItem;
        public ShellItem MWkItem;
        public ShellItem MUserItem;
        public ShellItem BalanceItem;
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
            MealItem = meal;
            MMealItem = mmeal;
            WkItem = workouts;
            MWkItem = mwk;
            MUserItem = muser;
            BalanceItem = balance;

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        public ShellItem GetWK()
        {
            return workouts;
        }

        public ShellItem GeMeal()
        {
            return meal;
        }

        public ShellItem GetMMeal()
        {
            return mmeal;
        }

        public ShellItem GetMWk()
        {
            return mwk;
        }

        public ShellItem GetMUsers()
        {
            return muser;
        }

        public ShellItem GetBalance()
        {
            return balance;
        }
    }
}
