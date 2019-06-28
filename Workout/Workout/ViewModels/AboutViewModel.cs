using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class AboutViewModel :BaseStrengthExerciseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}