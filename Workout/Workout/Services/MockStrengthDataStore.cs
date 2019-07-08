using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Squats", Weight=185, Reps=6, Sets=3, ExerciseDate = DateTime.Today, Note = string.Empty, Period = new TimeSpan(0, 0,0,0)},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Leg Press", Weight=360, Reps=6, Sets=3, ExerciseDate = DateTime.Today, Note = string.Empty, Period = new TimeSpan(0, 0,0,0)},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Romanian Deadlift", Weight=185, Reps=6, Sets=3, ExerciseDate = DateTime.Today, Note = string.Empty, Period = new TimeSpan(0, 0,0,0)},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Seated Calf", Weight=110, Reps=8, Sets=5, ExerciseDate = DateTime.Today, Note = string.Empty, Period = new TimeSpan(0, 0,0,0)},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Barbell Curls", Weight=70, Reps=10, Sets=3, ExerciseDate = DateTime.Today.AddDays(1), Note = string.Empty, Period = new TimeSpan(0, 0,0,0)},
                new StrengthExercise { Id = Guid.NewGuid().ToString(), Exercise = "Dumbell Curls", Weight=35, Reps=8, Sets=3, ExerciseDate = DateTime.Today.AddDays(1), Note = string.Empty, Period = new TimeSpan(0, 0,0,0)},

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
    }
}
