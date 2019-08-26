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

        public IEnumerable<ExerciseListItem> GetExerciseList()
        {
            //using database so get data
            List<ExerciseListItem> exercises = new List<ExerciseListItem>();
            SQLiteConnection conn;

            string sql = "SELECT * FROM [ExerciseList]";
            exercises = DB1.Query<ExerciseListItem>(sql);
                
            //base set of exercises
            //if count is zero add exercises to database
            if (exercises.Count == 0)
            {
                exercises.Add(new ExerciseListItem{Id=1, Value="Squats" });
                exercises.Add(new ExerciseListItem{Id=2, Value="Leg Press" });
                exercises.Add(new ExerciseListItem{Id=3, Value="Romanian Deadlift" });
                exercises.Add(new ExerciseListItem{Id=4, Value="Hack Squat" });
                exercises.Add(new ExerciseListItem{Id=5, Value="Lunges" });
                exercises.Add(new ExerciseListItem{Id=6, Value="Leg Curl" });
                exercises.Add(new ExerciseListItem{Id=7, Value="Leg Extension" });
                exercises.Add(new ExerciseListItem{Id=8, Value="Seated Calf" });
                exercises.Add(new ExerciseListItem{Id=9, Value="Standing Calf" });
                exercises.Add(new ExerciseListItem{Id=10, Value="Leg Press Calf" });
            
                exercises.Add(new ExerciseListItem{Id=20, Value="Barbell Bench Press" });
                exercises.Add(new ExerciseListItem{Id=21, Value="Dumbell Bench Press" });
                exercises.Add(new ExerciseListItem{Id=22, Value="Dumbell Fly" });
                exercises.Add(new ExerciseListItem{Id=23, Value="Cable Fly" });
                exercises.Add(new ExerciseListItem{Id=24, Value="Dips" });

            
                exercises.Add(new ExerciseListItem{Id=30, Value="Barbell Curl" });
                exercises.Add(new ExerciseListItem{Id=31, Value="Dumbell Curl" });
                exercises.Add(new ExerciseListItem{Id=32, Value="Hammer Curl" });
                exercises.Add(new ExerciseListItem{Id=33, Value="Preacher Curl" });
            
                exercises.Add(new ExerciseListItem{Id=40, Value="Tricep Pushdown" });
                exercises.Add(new ExerciseListItem{Id=41, Value="Tricep Pulldown" });
                exercises.Add(new ExerciseListItem{Id=42, Value="Overhead Tricep" });
                exercises.Add(new ExerciseListItem{Id=43, Value="Close Grip Bench" });
                exercises.Add(new ExerciseListItem{Id=44, Value="Tricep Extension" });

            
                exercises.Add(new ExerciseListItem{Id=50, Value="Deadlifts" });
                exercises.Add(new ExerciseListItem{Id=51, Value="PullUps/Chinups" });
                exercises.Add(new ExerciseListItem{Id=52, Value="Pulldowns" });
                exercises.Add(new ExerciseListItem{Id=53, Value="Seated Row" });
                exercises.Add(new ExerciseListItem{Id=54, Value="Bent Barbell Row" });
            
                exercises.Add(new ExerciseListItem{Id=60, Value="Barbell Military Press" });
                exercises.Add(new ExerciseListItem{Id=61, Value="Dumbell Military Press" });
                exercises.Add(new ExerciseListItem{Id=62, Value="Bent Over Lateral Raise" });
                exercises.Add(new ExerciseListItem{Id=63, Value="Side Lateral Raise" });
                exercises.Add(new ExerciseListItem{Id=64, Value="Front Raise" });

                exercises.Add(new ExerciseListItem{Id=70, Value="Abs" });
                exercises.Add(new ExerciseListItem{Id=90, Value="Cardio" });
                exercises.Add(new ExerciseListItem{Id=100, Value="Other" });
                //exercises.Add(91, "HIIT");

                //insert into database
                foreach (ExerciseListItem e in exercises){
                    DB1.Insert(e);
                }
            }

            return exercises;
        }
    }
}
