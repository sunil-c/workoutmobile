using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout.Models;
using Workout.Services;

namespace Workout.ViewModels
{
    public class StrengthExerciseDetailViewModel: BaseStrengthExerciseViewModel
    {

        public StrengthExercise Exercise { get; set; }
        public List<ExerciseListItem> ListOfExercises { get; set; }
        
        public StrengthExerciseDetailViewModel(String id = "")
        {
            this.ListOfExercises = ExerciseList.GetExerciseList(App.UseMockDataStore);
            _ = SetUpExercise(id);
        }

        private async Task SetUpExercise(string id)
        { 
            //init props
            Exercise = (await this.DataStore.GetExerciseAsync(id)).Clone() as StrengthExercise;
            Title = Exercise?.Exercise;
        }

    }
}
