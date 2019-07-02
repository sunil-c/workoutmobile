using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Workout.Models;
using Workout.ViewModels;
using Workout.Services;


namespace Workout.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class StrengthExerciseDetailPage : ContentPage
    {
        StrengthExerciseDetailViewModel viewModel;

        //constructor receives a viewModel
        public StrengthExerciseDetailPage(StrengthExerciseDetailViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            //Exercise is now a reference to the Exercise object in viewModel
            BindingContext = this.viewModel;
        }

        public void PickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((sender as Picker).SelectedItem == null)
                return;
            string selectedOption = (sender as Picker).SelectedItem.ToString();

            //only set new exercise name if changed
            if (viewModel.Exercise.Exercise != selectedOption)
            {
                viewModel.Exercise.Exercise = selectedOption;
            }
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteExercise", viewModel.Exercise);
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "UpdateExercise", viewModel.Exercise);
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            exPicker.SelectedIndex = exPicker.Items.IndexOf(viewModel.Exercise.Exercise);
        }

    }
}