using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout.Models;
using Workout.Services;

namespace Workout.Services
{
    public class ExerciseList
    {

        public List<ExerciseListItem> GetExerciseList(bool useMockDataStore)
        {
            List<ExerciseListItem> exercises = new List<ExerciseListItem>();
            SQLite.SQLiteConnection conn;

            //check the database if not using mock database
            if (useMockDataStore)
            {
                exercises.Add(new ExerciseListItem{Id=0, Value="Other" });
                exercises.Add(new ExerciseListItem{Id=90, Value="Cardio" });
                //exercises.Add(91, "HIIT");
            
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
            }
            else
            {
                string sql = "SELECT * FROM [ExerciseList]";
                conn = App.Database.GetConnection();
                exercises = conn.Query<ExerciseListItem>(sql);
                
                //if count is zero add exercises
                if (exercises.Count == 0)
                {
                    exercises.Add(new ExerciseListItem{Id=0, Value="Other" });
                    exercises.Add(new ExerciseListItem{Id=90, Value="Cardio" });
                    //exercises.Add(91, "HIIT");
            
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

                    foreach (ExerciseListItem e in exercises){
                        conn.Insert(e);
                    }
                }
            }

            return exercises;
        }

    }
}
