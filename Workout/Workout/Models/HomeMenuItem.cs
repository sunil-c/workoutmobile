using System;
using System.Collections.Generic;
using System.Text;

namespace Workout.Models
{
    public enum MenuItemType
    {
        //Browse,
        Exercises,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
