using System;
using Grind.Enums;

namespace Grind.Entities
{

    public class Time
    {
        public DayOfWeekEnum Day { get; set; }  // יום השבוע
        public DateTime TimeOfDay { get; set; } // זמן השיעור

        // בנאי
        public Time(DayOfWeekEnum day, DateTime timeOfDay)
        {
            Day = day;
            TimeOfDay = timeOfDay;
        }
        

        // פעולה להשוואת אם שני שיעורים מתרחשים באותו היום ובאותה השעה
        public bool IsSameTime(Time other)
        {
            return this.Day == other.Day && this.TimeOfDay.Hour == other.TimeOfDay.Hour;
        }
    }
}
