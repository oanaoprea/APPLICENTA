using App1.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {


        static UserDatabase database2;
        public static UserDatabase Database2
        {
            get
            {
                if (database == null)
                {
                    database2 = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "Users.db3"));
                }
                return database2;
            }
        }





        static MealsDatabase database;
        public static MealsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MealsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "Meals.db3"));
                }
                return database;
            }
        }

        static WorkoutsDatabase database1;
        public static WorkoutsDatabase Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new WorkoutsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "Workouts.db3"));
                }
                return database1;
            }
        }


        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
