using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Workout.Models;

namespace Workout.Services
{
    public class ExerciseListDatabase : IExercisesDataStore<ExerciseListItem>
    {
        private SQLiteConnection _dB1;
        public SQLiteConnection DB1 { get {return _dB1;} }

        public ExerciseListDatabase()
        {
            _dB1 = App.Database.GetConnection();
        }

        public async Task<bool> AddExerciseAsync(ExerciseListItem item)
        {
            DB1.Insert(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteExerciseAsync(int id)
        {
            DB1.Table<ExerciseListItem>().Delete(i => i.Id == id);
            return await Task.FromResult(true);
        }

        public SQLiteConnection GetConnection()
        {
            return DB1;
        }

        public async Task<ExerciseListItem> GetExerciseAsync(int id)
        {
            ExerciseListItem result = DB1.Table<ExerciseListItem>().FirstOrDefault(i => i.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ExerciseListItem>> GetExercisesAsync(bool forceRefresh = false)
        {
            string sql = "SELECT * FROM [ExerciseList]";
            List<ExerciseListItem> result = DB1.Query<ExerciseListItem>(sql);
            return await Task.FromResult(result.FindAll(i => i.Id > 0));
        }

        public IEnumerable<ExerciseListItem> GetExercises()
        {
            string sql = "SELECT * FROM [ExerciseList]";
            return DB1.Query<ExerciseListItem>(sql);
        }

        public async Task<bool> UpdateExerciseAsync(ExerciseListItem item)
        {
            DB1.Update(item);
            return await Task.FromResult(true);
        }

    }
}
