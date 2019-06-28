using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Workout.Models;
using Workout.Views;
using Workout.ViewModels;

namespace Workout.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class StrengthExercisesPage : ContentPage
    {
        StrengthExerciseViewModel viewModel;

        public StrengthExercisesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new StrengthExerciseViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            //have to always check for null because setting the selecteditem to null fires this again
            if (((ListView) sender).SelectedItem == null) 
                return;
            StrengthExercise exercise = (args.SelectedItem as StrengthExercise).Clone() as StrengthExercise;

            await Navigation.PushModalAsync(new NavigationPage(new StrengthExerciseDetailPage(new StrengthExerciseDetailViewModel(exercise))));
            // Manually deselect item in UI
            ((ListView)sender).SelectedItem = null;
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            viewModel.LoadExercisesCommand.Execute(null);
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewStrengthExercisePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Exercises.Count == 0)
            {
                viewModel.LoadExercisesCommand.Execute(null);
            }
        }
    }
}