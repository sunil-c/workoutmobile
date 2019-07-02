using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Workout.Models;
using Workout.Views;
using System.Linq;

namespace Workout.ViewModels
{
    public class StrengthExerciseViewModel : BaseStrengthExerciseViewModel
    {
        public ObservableCollection<StrengthExercise> Exercises { get; set; }
        public Command LoadExercisesCommand { get; set; }
        public DateTime SelectedDate { get; set; }

        //constructor
        public StrengthExerciseViewModel()
        {
            Title = "Exercises";
            //data store
            Exercises = new ObservableCollection<StrengthExercise>();
            //set commands
            LoadExercisesCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //default to today
            SelectedDate = DateTime.Today;

            //define messages this view model can receive
            MessagingCenter.Subscribe<NewStrengthExercisePage, StrengthExercise>(this, "AddExercise", async (obj, item) =>
            {
                //add to source data
                await DataStore.AddExerciseAsync(item);
            });
            MessagingCenter.Subscribe<StrengthExerciseDetailPage, StrengthExercise>(this, "DeleteExercise", async (obj, item) =>
            {
                //remove from the local data store
                Exercises.Remove(Exercises.FirstOrDefault(s => s.Id == item.Id));
                //remove from source data
                await DataStore.DeleteExerciseAsync(item.Id);
            });
            MessagingCenter.Subscribe<StrengthExerciseDetailPage, StrengthExercise>(this, "UpdateExercise", async (obj, item) =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                try
                {
                    //update the source data
                    await DataStore.UpdateExerciseAsync(item);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            });

        }


        //what to do to load items
        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                this.Exercises.Clear();
                var items = await DataStore.GetExercisesAsync(SelectedDate, true);
                foreach (var item in items)
                {
                    this.Exercises.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}