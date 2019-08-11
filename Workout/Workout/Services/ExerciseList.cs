using System;
using System.Collections.Generic;
using SQLite;
using Workout.Models;

namespace Workout.Services
{
    public class ExerciseList
    {

        public List<ExerciseListItem> GetExerciseList(bool useMockDataStore)
        {
            List<ExerciseListItem> exercises = new List<ExerciseListItem>();
            SQLiteConnection conn;

            //check if using mock database
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
                exercises.Add(new ExerciseListItem{Id=11, Value="Step-Up" });
                exercises.Add(new ExerciseListItem{Id=12, Value="Good Mornings" });
            
                exercises.Add(new ExerciseListItem{Id=20, Value="Barbell Bench Press" });
                exercises.Add(new ExerciseListItem{Id=21, Value="Dumbell Bench Press" });
                exercises.Add(new ExerciseListItem{Id=22, Value="Dumbell Fly" });
                exercises.Add(new ExerciseListItem{Id=23, Value="Cable Fly" });
                exercises.Add(new ExerciseListItem{Id=24, Value="Parallel Dips" });
                exercises.Add(new ExerciseListItem{Id=25, Value="Barbell Incline Press" });
                exercises.Add(new ExerciseListItem{Id=26, Value="Dumbell Incline Press" });
                exercises.Add(new ExerciseListItem{Id=27, Value="Decline Bench Press" });
                exercises.Add(new ExerciseListItem{Id=28, Value="Push-Ups" });

                exercises.Add(new ExerciseListItem{Id=30, Value="Barbell Curl" });
                exercises.Add(new ExerciseListItem{Id=31, Value="Dumbell Curl" });
                exercises.Add(new ExerciseListItem{Id=32, Value="Hammer Curl" });
                exercises.Add(new ExerciseListItem{Id=33, Value="Preacher Curl" });
                exercises.Add(new ExerciseListItem{Id=34, Value="Alternating Dumbell Curl" });
                exercises.Add(new ExerciseListItem{Id=35, Value="Reverse Curl" });
                exercises.Add(new ExerciseListItem{Id=36, Value="Wrist Curl" });

                exercises.Add(new ExerciseListItem{Id=40, Value="Tricep Pushdown" });
                exercises.Add(new ExerciseListItem{Id=41, Value="Tricep Pulldown" });
                exercises.Add(new ExerciseListItem{Id=42, Value="Overhead Tricep" });
                exercises.Add(new ExerciseListItem{Id=43, Value="Close Grip Bench" });
                exercises.Add(new ExerciseListItem{Id=44, Value="Tricep Extension" });
                exercises.Add(new ExerciseListItem{Id=45, Value="Tricep Pullover" });
                exercises.Add(new ExerciseListItem{Id=46, Value="Skull Crushers" });
            
                exercises.Add(new ExerciseListItem{Id=50, Value="Deadlifts" });
                exercises.Add(new ExerciseListItem{Id=51, Value="PullUps/Chinups" });
                exercises.Add(new ExerciseListItem{Id=52, Value="Pulldowns" });
                exercises.Add(new ExerciseListItem{Id=53, Value="Seated Row" });
                exercises.Add(new ExerciseListItem{Id=54, Value="Bent Barbell Row" });
                exercises.Add(new ExerciseListItem{Id=54, Value="Pull-ups/Chin-ups" });
                exercises.Add(new ExerciseListItem{Id=55, Value="Dumbell Row" });
            
                exercises.Add(new ExerciseListItem{Id=60, Value="Barbell Military Press" });
                exercises.Add(new ExerciseListItem{Id=61, Value="Dumbell Military Press" });
                exercises.Add(new ExerciseListItem{Id=62, Value="Bent Over Lateral Raise" });
                exercises.Add(new ExerciseListItem{Id=63, Value="Side Lateral Raise" });
                exercises.Add(new ExerciseListItem{Id=64, Value="Front Raise" });
                exercises.Add(new ExerciseListItem{Id=65, Value="Shoulder Shrugs" });
                exercises.Add(new ExerciseListItem{Id=66, Value="Upright Rows" });

                exercises.Add(new ExerciseListItem{Id=70, Value="Abs" });
            }
            else
            {
                //using database so get data
                string sql = "SELECT * FROM [ExerciseList]";
                conn = App.Database.GetConnection();
                exercises = conn.Query<ExerciseListItem>(sql);
                
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
                        conn.Insert(e);
                    }
                }
            }

            return exercises;
        }

    }





}
