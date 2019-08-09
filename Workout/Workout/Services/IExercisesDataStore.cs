using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Workout.Services
{
    public interface IExercisesDataStore<T>
    {
        Task<bool> AddExerciseAsync(T item);
        Task<bool> UpdateExerciseAsync(T item);
        Task<bool> DeleteExerciseAsync(int id);
        Task<T> GetExerciseAsync(int id);
        Task<IEnumerable<T>> GetExercisesAsync(bool forceRefresh = false);
        IEnumerable<T> GetExercises();
        SQLiteConnection GetConnection();
    }
}
