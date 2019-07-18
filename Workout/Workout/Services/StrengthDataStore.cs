using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Workout.Models;

namespace Workout.Services
{
    public class ExerciseDatabase: IStrengthDataStore<StrengthExercise>
    {
        //readonly SQLiteAsyncConnection database;
        private readonly SQLiteConnection db1;

        public ExerciseDatabase(string dbPath)
        {
            db1 = new SQLiteConnection(dbPath);
            db1.CreateTable<StrengthExercise>();
        }

        public async Task<bool> AddExerciseAsync(StrengthExercise item)
        {
            db1.Insert(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateExerciseAsync(StrengthExercise item)
        {
            db1.Update(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteExerciseAsync(string id)
        {
            db1.Table<StrengthExercise>().Delete(i => i.Id == id);
            return await Task.FromResult(true);
        }

        public async Task<StrengthExercise> GetExerciseAsync(string id)
        {
            StrengthExercise result = db1.Table<StrengthExercise>().FirstOrDefault(i => i.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<StrengthExercise>> GetExercisesAsync(DateTime dt, bool forceRefresh = false)
        {
            string sql = "SELECT * FROM [StrengthExercise]";
            List<StrengthExercise> result = db1.Query<StrengthExercise>(sql);
            return await Task.FromResult(result.FindAll(i => i.ExerciseDate == dt));
        }

        //public async Task<Dictionary<int, string>> GetExerciseListAsync(string id)
        //{
        //    string sql = "SELECT * FROM [ExerciseList]";

        //    return await Task.FromResult(result);
        //}
    }
}
