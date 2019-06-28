using System;
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

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<MockStrengthDataStore>();

            }
            else
            {
                //needs to be changed to azure data store once code is written
                DependencyService.Register<MockStrengthDataStore>();
                //DependencyService.Register<AzureDataStore>();
            }
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
