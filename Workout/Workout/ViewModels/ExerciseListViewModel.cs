using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Workout.Models;
using Workout.Services;
using Xamarin.Forms;
using Workout.Views;
using System.Linq;
using System.Collections.ObjectModel;

namespace Workout.ViewModels
{
    public class BaseExerciseListViewModel: INotifyPropertyChanged
    {
        //semaphore
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        //page title
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        //invokes the notify property changed event
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class ExerciseListViewModel: BaseExerciseListViewModel
    {
        public ObservableCollection<ExerciseListItem> ListOfExercises { get; set; }
        public Command LoadExercisesCommand { get; set; }
        private IExercisesDataStore<ExerciseListItem> DataStore;

        public ExerciseListViewModel()
        {
            Title = "Exercise List";
            DataStore = new ExerciseListDatabase();
            ListOfExercises = new ObservableCollection<ExerciseListItem>();

            var x = DataStore.GetExercises();
            foreach(ExerciseListItem i in x){ this.ListOfExercises.Add(i); }
            //set commands
            LoadExercisesCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //define messages this view model can receive
            MessagingCenter.Subscribe<ExerciseListPage, ExerciseListItem>(this, "AddExercise", async (obj, item) =>
            {
                //add to source data
                int maxId = ListOfExercises.Any<ExerciseListItem>() ? ListOfExercises.Aggregate((i1,i2) => i1.Id > i2.Id ? i1 : i2).Id : 1000;
                item.Id = maxId >= 1000 ? maxId + 10: 1000;
                await DataStore.AddExerciseAsync(item);
            });
            //define messages this view model can receive
            MessagingCenter.Subscribe<ExerciseListPage, ExerciseListItem>(this, "DeleteExercise", async (obj, item) =>
            {
                //remove from the local data store
                ListOfExercises.Remove(ListOfExercises.FirstOrDefault(s => s.Id == item.Id));
                //remove from source data
                await DataStore.DeleteExerciseAsync(item.Id);
            });
            //define messages this view model can receive
            MessagingCenter.Subscribe<ExerciseListPage, ExerciseListItem>(this, "UpdateExercise", async (obj, item) =>
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
                this.ListOfExercises.Clear();
                var x = await DataStore.GetExercisesAsync();
                foreach(ExerciseListItem i in x){ this.ListOfExercises.Add(i); }
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
