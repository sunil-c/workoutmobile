using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workout.Services
{
    //add new exercises here
    //enum ListofExercises
    //{
    //    Squats = 1,
    //    LegPress = 2,
    //    RomanianDeadlift = 3,
    //    LegCurl = 4,
    //    SeatedCalf = 5,
    //    StandingCalf = 6,
    //    LegPressCalf = 7,

    //    BarbellBenchPress = 20,
    //    DumbellBenchPress = 21,
    //    DumbellFly = 22,
    //    CableFly = 23,

    //    BarbellCurl = 30,
    //    DumbellCurl = 31,
    //    HammerCurl = 32,

    //    TricepPushdown = 40,
    //    TricepPulldown = 41,
    //    OverheadTricep = 42,
    //    CloseGripBench = 43,

    //    Deadlifts = 50,
    //    PullUps = 51,
    //    Pulldowns = 52,
    //    SeatedRow = 53,
    //    BentBarbellRow = 54,

    //    BarbellMilitaryPress = 60,
    //    DumbellMilitaryPress = 61,
    //    BentOverLateralRaise = 62,
    //    SideLateralRaise = 63,
    //    FrontRaise = 64
    //}

    public class ExerciseList
    {
        //returnt he ListOfExercises enum as a dictionary
        //private static Dictionary<int, string> GetExerciseList_z()
        //{
        //    Dictionary<int, string> exercises = new Dictionary<int, string>();
        //    var values = Enum.GetValues(typeof(ListofExercises)).Cast<int>();
        //    foreach (int item in values){
        //        exercises.Add(item, Enum.GetName(typeof(ListofExercises), item));
        //    }
        //    return exercises;
        //}

        //return the exercises available as a dictionary
        //to-do move to database
        public static Dictionary<int, string> GetExerciseList()
        {
            Dictionary<int, string> exercises = new Dictionary<int, string>();
            exercises.Add(0, "Other");
            exercises.Add(1, "Squats");
            exercises.Add(2, "Leg Press");
            exercises.Add(3, "Romanian Deadlift");
            exercises.Add(4, "Leg Curl");
            exercises.Add(5, "Seated Calf");
            exercises.Add(6, "Standing Calf");
            exercises.Add(7, "Leg Press Calf");
            exercises.Add(20, "Barbell Bench Press");
            exercises.Add(21, "Dumbell Bench Press");
            exercises.Add(22, "Dumbell Fly");
            exercises.Add(23, "Cable Fly");
            exercises.Add(30, "Barbell Curl");
            exercises.Add(31, "Dumbell Curl");
            exercises.Add(32, "Hammer Curl");
            exercises.Add(40, "Tricep Pushdown");
            exercises.Add(41, "Tricep Pulldown");
            exercises.Add(42, "Overhead Tricep");
            exercises.Add(43, "Close Grip Bench");
            exercises.Add(50, "Deadlifts");
            exercises.Add(51, "PullUps");
            exercises.Add(52, "Pulldowns");
            exercises.Add(53, "Seated Row");
            exercises.Add(54, "Bent Barbell Row");
            exercises.Add(60, "Barbell Military Press");
            exercises.Add(61, "Dumbell Military Press");
            exercises.Add(62, "Bent Over Lateral Raise");
            exercises.Add(63, "Side Lateral Raise");
            exercises.Add(64, "Front Raise");

            return exercises;
        }
    }
}
