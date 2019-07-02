using System;

namespace Workout.Models
{
    public class StrengthExercise: ICloneable
    {
        public string Id { get; set; }
        public string Exercise {get; set;}
        public decimal Weight { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public DateTime ExerciseDate { get; set; }
        public string Note { get; set; }

        //object copy routine
        public object Clone()
        {
            return new StrengthExercise
            {
                Exercise = this.Exercise, ExerciseDate = this.ExerciseDate,
                Id = this.Id, Reps = this.Reps, Sets = this.Sets, Weight = this.Weight,
                Note = this.Note
            };
        }

    }


}
