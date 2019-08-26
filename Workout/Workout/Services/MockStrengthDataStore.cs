using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Workout.Models;

namespace Workout.Services
{
    public class MockStrengthDataStore : IStrengthDataStore<StrengthExercise>
    {
        List<StrengthExercise> exercises;

        public MockStrengthDataStore()
        {
            exercises = new List<StrengthExercise>();

            //to-do get from database
            var mockExercises = new List<StrengthExercise>
            {
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Squats", Weight=185, Reps=6, Sets=3, ExerciseDate = DateTime.Today, Note = string.Empty, Hours=0, Mins=0, Secs=0, Distance=0},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Leg Press", Weight=360, Reps=6, Sets=3, ExerciseDate = DateTime.Today, Note = string.Empty, Hours=0, Mins=0, Secs=0, Distance=0},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Romanian Deadlift", Weight=185, Reps=6, Sets=3, ExerciseDate = DateTime.Today, Note = string.Empty, Hours=0, Mins=0, Secs=0, Distance=0},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Seated Calf", Weight=110, Reps=8, Sets=5, ExerciseDate = DateTime.Today, Note = string.Empty, Hours=0, Mins=0, Secs=0, Distance=0},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Barbell Curls", Weight=70, Reps=10, Sets=3, ExerciseDate = DateTime.Today.AddDays(1), Note = string.Empty, Hours=0, Mins=0, Secs=0, Distance=0},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Dumbell Curls", Weight=35, Reps=8, Sets=3, ExerciseDate = DateTime.Today.AddDays(1), Note = string.Empty, Hours=0, Mins=0, Secs=0, Distance=0},

            };

            foreach (var exercise in mockExercises)
            {
                exercises.Add(exercise);
            }
        }

        public async Task<bool> AddExerciseAsync(StrengthExercise exercise)
        {
            //add the passed in exercise
            exercises.Add(exercise);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateExerciseAsync(StrengthExercise exercise)
        {
            //remove then old one, add a new one
            var oldItem = exercises.FirstOrDefault((StrengthExercise arg) => arg.Id == exercise.Id);
            exercises.Remove(oldItem);
            exercises.Add(exercise);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteExerciseAsync(string id)
        {
            //remove the exercise
            var oldItem = exercises.FirstOrDefault((StrengthExercise arg) => arg.Id == id);
            exercises.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<StrengthExercise> GetExerciseAsync(string id)
        {
            //return one
            return await Task.FromResult(exercises.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<StrengthExercise>> GetExercisesAsync(DateTime dt, bool forceRefresh = false)
        {
            //return all for a date
            return await Task.FromResult(exercises.FindAll(i => i.ExerciseDate == dt));
        }

        public SQLiteConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseListItem> GetExerciseList()
        {
            List<ExerciseListItem> exerciseList = new List<ExerciseListItem>();

            exerciseList.Add(new ExerciseListItem{Id=0, Value="Other" });
            exerciseList.Add(new ExerciseListItem{Id=90, Value="Cardio" });
            //exerciseList.Add(91, "HIIT");
            
            exerciseList.Add(new ExerciseListItem{Id=1, Value="Squats" });
            exerciseList.Add(new ExerciseListItem{Id=2, Value="Leg Press" });
            exerciseList.Add(new ExerciseListItem{Id=3, Value="Romanian Deadlift" });
            exerciseList.Add(new ExerciseListItem{Id=4, Value="Hack Squat" });
            exerciseList.Add(new ExerciseListItem{Id=5, Value="Lunges" });
            exerciseList.Add(new ExerciseListItem{Id=6, Value="Leg Curl" });
            exerciseList.Add(new ExerciseListItem{Id=7, Value="Leg Extension" });
            exerciseList.Add(new ExerciseListItem{Id=8, Value="Seated Calf" });
            exerciseList.Add(new ExerciseListItem{Id=9, Value="Standing Calf" });
            exerciseList.Add(new ExerciseListItem{Id=10, Value="Leg Press Calf" });
            exerciseList.Add(new ExerciseListItem{Id=11, Value="Step-Up" });
            exerciseList.Add(new ExerciseListItem{Id=12, Value="Good Mornings" });
            
            exerciseList.Add(new ExerciseListItem{Id=20, Value="Barbell Bench Press" });
            exerciseList.Add(new ExerciseListItem{Id=21, Value="Dumbell Bench Press" });
            exerciseList.Add(new ExerciseListItem{Id=22, Value="Dumbell Fly" });
            exerciseList.Add(new ExerciseListItem{Id=23, Value="Cable Fly" });
            exerciseList.Add(new ExerciseListItem{Id=24, Value="Parallel Dips" });
            exerciseList.Add(new ExerciseListItem{Id=25, Value="Barbell Incline Press" });
            exerciseList.Add(new ExerciseListItem{Id=26, Value="Dumbell Incline Press" });
            exerciseList.Add(new ExerciseListItem{Id=27, Value="Decline Bench Press" });
            exerciseList.Add(new ExerciseListItem{Id=28, Value="Push-Ups" });

            exerciseList.Add(new ExerciseListItem{Id=30, Value="Barbell Curl" });
            exerciseList.Add(new ExerciseListItem{Id=31, Value="Dumbell Curl" });
            exerciseList.Add(new ExerciseListItem{Id=32, Value="Hammer Curl" });
            exerciseList.Add(new ExerciseListItem{Id=33, Value="Preacher Curl" });
            exerciseList.Add(new ExerciseListItem{Id=34, Value="Alternating Dumbell Curl" });
            exerciseList.Add(new ExerciseListItem{Id=35, Value="Reverse Curl" });
            exerciseList.Add(new ExerciseListItem{Id=36, Value="Wrist Curl" });

            exerciseList.Add(new ExerciseListItem{Id=40, Value="Tricep Pushdown" });
            exerciseList.Add(new ExerciseListItem{Id=41, Value="Tricep Pulldown" });
            exerciseList.Add(new ExerciseListItem{Id=42, Value="Overhead Tricep" });
            exerciseList.Add(new ExerciseListItem{Id=43, Value="Close Grip Bench" });
            exerciseList.Add(new ExerciseListItem{Id=44, Value="Tricep Extension" });
            exerciseList.Add(new ExerciseListItem{Id=45, Value="Tricep Pullover" });
            exerciseList.Add(new ExerciseListItem{Id=46, Value="Skull Crushers" });
            
            exerciseList.Add(new ExerciseListItem{Id=50, Value="Deadlifts" });
            exerciseList.Add(new ExerciseListItem{Id=51, Value="PullUps/Chinups" });
            exerciseList.Add(new ExerciseListItem{Id=52, Value="Pulldowns" });
            exerciseList.Add(new ExerciseListItem{Id=53, Value="Seated Row" });
            exerciseList.Add(new ExerciseListItem{Id=54, Value="Bent Barbell Row" });
            exerciseList.Add(new ExerciseListItem{Id=54, Value="Pull-ups/Chin-ups" });
            exerciseList.Add(new ExerciseListItem{Id=55, Value="Dumbell Row" });
            
            exerciseList.Add(new ExerciseListItem{Id=60, Value="Barbell Military Press" });
            exerciseList.Add(new ExerciseListItem{Id=61, Value="Dumbell Military Press" });
            exerciseList.Add(new ExerciseListItem{Id=62, Value="Bent Over Lateral Raise" });
            exerciseList.Add(new ExerciseListItem{Id=63, Value="Side Lateral Raise" });
            exerciseList.Add(new ExerciseListItem{Id=64, Value="Front Raise" });
            exerciseList.Add(new ExerciseListItem{Id=65, Value="Shoulder Shrugs" });
            exerciseList.Add(new ExerciseListItem{Id=66, Value="Upright Rows" });

            exerciseList.Add(new ExerciseListItem{Id=70, Value="Abs" });

            return exerciseList;
        }
    }
}
