using System;
using System.Collections.Generic;
using System.Text;

namespace Workout.Models
{
    /* TO ADD A MENU ITEM TO THE APP
     * modify the following files: 
     * MenuItemType enum (below)
     * menupage.xaml.cs
     * mainpage.xaml.cs 
     */
    public enum MenuItemType
    {
        Exercises,
        Stopwatch,
        ExerciseList,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
