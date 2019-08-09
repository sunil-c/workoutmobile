using Workout.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Workout.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.Exercises, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            //        ******** To add a new menu item ********           //
            // 1. add a new MenuItemType                                 //
            // 2. Modify Menu Page and add a new menu item type to list  //
            // 3. Modify the case statement below                        //

            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Exercises:
                        MenuPages.Add(id, new NavigationPage(new StrengthExercisesPage()));
                        break;
                    case (int)MenuItemType.Stopwatch:
                        MenuPages.Add(id, new NavigationPage(new StopWatchPage()));
                        break;
                    case (int)MenuItemType.ExerciseList:
                        MenuPages.Add(id, new NavigationPage(new ExerciseListPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}