using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workout.Models;

namespace Workout.Services
{
    public class ExerciseList
    {

        public static List<ExerciseListItem> GetExerciseList(bool useMockDataStore)
        {
            List<ExerciseListItem> exercises = new List<ExerciseListItem>();

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

            return exercises;
        }

        ////return the exercises available as a dictionary
        ////to-do move to database
        //public static Dictionary<int, string> GetExerciseList(bool useMockDataStore)
        //{
        //    Dictionary<int, string> exercises = new Dictionary<int, string>();
        //    //check the database if not using mock database
        //    if (useMockDataStore)
        //    {
        //        exercises.Add(0, "Other");
        //        exercises.Add(90, "Cardio");
        //        //exercises.Add(91, "HIIT");
            
        //        exercises.Add(1, "Squats");
        //        exercises.Add(2, "Leg Press");
        //        exercises.Add(3, "Romanian Deadlift");
        //        exercises.Add(4, "Hack Squat");
        //        exercises.Add(5, "Lunges");
            
        //        exercises.Add(6, "Leg Curl");
        //        exercises.Add(7, "Leg Extension");
        //        exercises.Add(8, "Seated Calf");
        //        exercises.Add(9, "Standing Calf");
        //        exercises.Add(10, "Leg Press Calf");
            
        //        exercises.Add(20, "Barbell Bench Press");
        //        exercises.Add(21, "Dumbell Bench Press");
        //        exercises.Add(22, "Dumbell Fly");
        //        exercises.Add(23, "Cable Fly");
        //        exercises.Add(24, "Dips");

            
        //        exercises.Add(30, "Barbell Curl");
        //        exercises.Add(31, "Dumbell Curl");
        //        exercises.Add(32, "Hammer Curl");
        //        exercises.Add(33, "Preacher Curl");
            
        //        exercises.Add(40, "Tricep Pushdown");
        //        exercises.Add(41, "Tricep Pulldown");
        //        exercises.Add(42, "Overhead Tricep");
        //        exercises.Add(43, "Close Grip Bench");
        //        exercises.Add(44, "Tricep Extension");

            
        //        exercises.Add(50, "Deadlifts");
        //        exercises.Add(51, "PullUps/Chinups");
        //        exercises.Add(52, "Pulldowns");
        //        exercises.Add(53, "Seated Row");
        //        exercises.Add(54, "Bent Barbell Row");
            
        //        exercises.Add(60, "Barbell Military Press");
        //        exercises.Add(61, "Dumbell Military Press");
        //        exercises.Add(62, "Bent Over Lateral Raise");
        //        exercises.Add(63, "Side Lateral Raise");
        //        exercises.Add(64, "Front Raise");

        //        exercises.Add(70, "Abs");

        //        return exercises;
        //    }
        //    else
        //    {
        //        //needs to be replaced with code getting data from sqlite

        //        exercises.Add(0, "Other");
        //        exercises.Add(90, "Cardio");
        //        //exercises.Add(91, "HIIT");
            
        //        exercises.Add(1, "Squats");
        //        exercises.Add(2, "Leg Press");
        //        exercises.Add(3, "Romanian Deadlift");
        //        exercises.Add(4, "Hack Squat");
        //        exercises.Add(5, "Lunges");
            
        //        exercises.Add(6, "Leg Curl");
        //        exercises.Add(7, "Leg Extension");
        //        exercises.Add(8, "Seated Calf");
        //        exercises.Add(9, "Standing Calf");
        //        exercises.Add(10, "Leg Press Calf");
            
        //        exercises.Add(20, "Barbell Bench Press");
        //        exercises.Add(21, "Dumbell Bench Press");
        //        exercises.Add(22, "Dumbell Fly");
        //        exercises.Add(23, "Cable Fly");
        //        exercises.Add(24, "Dips");

            
        //        exercises.Add(30, "Barbell Curl");
        //        exercises.Add(31, "Dumbell Curl");
        //        exercises.Add(32, "Hammer Curl");
        //        exercises.Add(33, "Preacher Curl");
            
        //        exercises.Add(40, "Tricep Pushdown");
        //        exercises.Add(41, "Tricep Pulldown");
        //        exercises.Add(42, "Overhead Tricep");
        //        exercises.Add(43, "Close Grip Bench");
        //        exercises.Add(44, "Tricep Extension");

            
        //        exercises.Add(50, "Deadlifts");
        //        exercises.Add(51, "PullUps/Chinups");
        //        exercises.Add(52, "Pulldowns");
        //        exercises.Add(53, "Seated Row");
        //        exercises.Add(54, "Bent Barbell Row");
            
        //        exercises.Add(60, "Barbell Military Press");
        //        exercises.Add(61, "Dumbell Military Press");
        //        exercises.Add(62, "Bent Over Lateral Raise");
        //        exercises.Add(63, "Side Lateral Raise");
        //        exercises.Add(64, "Front Raise");

        //        exercises.Add(70, "Abs");

        //        return exercises;
        //    }

        //}
    }
}
