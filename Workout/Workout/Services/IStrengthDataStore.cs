using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workout.Models;

namespace Workout.Services
{
    //used by the Mock DataStore and Strength DataStore
    public interface IStrengthDataStore<T>
    {
        Task<bool> AddExerciseAsync(T item);
        Task<bool> UpdateExerciseAsync(T item);
        Task<bool> DeleteExerciseAsync(string id);
        Task<T> GetExerciseAsync(string id);
        Task<IEnumerable<T>> GetExercisesAsync(DateTime dt, bool forceRefresh = false);
        IEnumerable<ExerciseListItem> GetExerciseList();
        SQLiteConnection GetConnection();
    }
}
