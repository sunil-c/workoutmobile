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
        public List<string> ListOfExercises { get; set; }
        
        public StrengthExerciseDetailViewModel(StrengthExercise exercise = null)
        {
            Title = exercise?.Exercise;
            //init props
            this.ListOfExercises = ExerciseList.GetExerciseList().Values.ToList();
            //init the data
            this.Exercise = exercise;
        }

    }
}
