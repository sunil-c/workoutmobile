using System;
using System.IO;
using Workout.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Workout.Services;
using Workout.Views;

namespace Workout
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;

        private static string databaseName = "ExerciseSQLite.db3";
        //create a read only global database variable
        private static IStrengthDataStore<StrengthExercise> _database;
        public static IStrengthDataStore<StrengthExercise> Database
        {
            get
            {
                if (_database == null)
                {
                    //use the mock database when developing
                    if (UseMockDataStore)
                    {
                        _database = new MockStrengthDataStore();
                    }
                    else
                    {
                        _database = new ExerciseDatabase(
                            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), databaseName));
                    }

                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
