using System;
using System.Collections.Generic;
using System.ComponentModel;
using Workout.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Workout.Models;
using System.Linq;

namespace Workout.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class NewStrengthExercisePage : ContentPage
    {
        public StrengthExercise Exercise { get; set; }
        public List<string> ListOfExercises;
        public NewStrengthExercisePage()
        {
            InitializeComponent();

            Exercise = new StrengthExercise
            {
                 Id = Guid.NewGuid().ToString(),
                 Exercise = "",
                 Weight = 0,
                 Sets = 0,
                 Reps = 0,
                 ExerciseDate = DateTime.Today
            };

            //call static function to get exercises and bind them to pick list
            ListOfExercises = ExerciseList.GetExerciseList().Values.ToList();
            exPicker.ItemsSource = ListOfExercises;

            //add a selected item change event to pick list
            exPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (exPicker.SelectedIndex == -1)
                {
                    Exercise.Exercise = "";
                }
                else
                {
                    Exercise.Exercise = exPicker.Items[exPicker.SelectedIndex];
                }
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddExercise", Exercise);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}