using System;
using SQLite;

namespace Workout.Models
{
    [Table("ExerciseList")]
    public class ExerciseListItem
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Value { get; set; }
    }

    [Table("StrengthExercise")]
    public class StrengthExercise: ICloneable
    {
        [PrimaryKey]
        public string Id { get; set; }
        public DateTime ExerciseDate { get; set; }
        
        public string Exercise {get; set;}
        
        public decimal Weight { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }

        //used to store elapsed time for cardio
        public bool IsCardio { get; set; }
        public int Hours { get; set; }
        public int Mins { get; set; }
        public int Secs { get; set; }
        public decimal Distance { get; set; }

        //store notes with workout
        public string Note { get; set; }

        //object copy routine
        public object Clone()
        {
            return new StrengthExercise
            {
                Exercise = this.Exercise, ExerciseDate = this.ExerciseDate,
                Id = this.Id, Reps = this.Reps, Sets = this.Sets, Weight = this.Weight,
                Note = this.Note, Hours = this.Hours, Mins = this.Mins, Secs = this.Secs,
                Distance = this.Distance, IsCardio = this.IsCardio
            };
        }

    }


}
