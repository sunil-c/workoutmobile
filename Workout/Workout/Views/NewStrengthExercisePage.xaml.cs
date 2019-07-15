using System;
using System.Collections.Generic;
using System.ComponentModel;
using Workout.Services;
using Xamarin.Forms;
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
        private Dictionary<int, string> _exerciseList;
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
            _exerciseList = ExerciseList.GetExerciseList();
            ListOfExercises = _exerciseList.Values.ToList();
            exPicker.ItemsSource = ListOfExercises;

            cardioVals.IsVisible = false;

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
                    int key = _exerciseList.FirstOrDefault(x => x.Value == Exercise.Exercise).Key;
                    switch (key)
                    {
                        case 0:
                            strengthVals.IsVisible = false;
                            cardioVals.IsVisible = false;
                            break;
                        case 90:
                            strengthVals.IsVisible = false;
                            cardioVals.IsVisible = true;                            
                            break;
                        default:
                            strengthVals.IsVisible = true;
                            cardioVals.IsVisible = false;
                            break;
                    }
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