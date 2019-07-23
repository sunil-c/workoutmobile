using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Workout.Models;

namespace Workout.Services
{
    public class ExerciseDatabase : IStrengthDataStore<StrengthExercise>
    {
        private SQLiteConnection _dB1;
        public SQLiteConnection DB1 { get {return _dB1;} }

        public ExerciseDatabase(string dbPath)
        {
            _dB1 = new SQLiteConnection(dbPath);
            DB1.CreateTable<StrengthExercise>();
            DB1.CreateTable<ExerciseListItem>();
        }

        public SQLiteConnection GetConnection()
        {
            return DB1;
        }

        public async Task<bool> AddExerciseAsync(StrengthExercise item)
        {
            DB1.Insert(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateExerciseAsync(StrengthExercise item)
        {
            DB1.Update(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteExerciseAsync(string id)
        {
            DB1.Table<StrengthExercise>().Delete(i => i.Id == id);
            return await Task.FromResult(true);
        }

        public async Task<StrengthExercise> GetExerciseAsync(string id)
        {
            StrengthExercise result = DB1.Table<StrengthExercise>().FirstOrDefault(i => i.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<StrengthExercise>> GetExercisesAsync(DateTime dt, bool forceRefresh = false)
        {
            string sql = "SELECT * FROM [StrengthExercise]";
            List<StrengthExercise> result = DB1.Query<StrengthExercise>(sql);
            return await Task.FromResult(result.FindAll(i => i.ExerciseDate == dt));
        }

        private async Task<IEnumerable<ExerciseListItem>> GetExerciseListAsync(string id)
        {
            string sql = "SELECT * FROM [ExerciseList]";
            List<ExerciseListItem> result = DB1.Query<ExerciseListItem>(sql);
            return await Task.FromResult(result);
        }
    }
}
