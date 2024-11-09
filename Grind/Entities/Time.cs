using Grind.Enums;
using System;

namespace Grind.Entities
{
    public class Time
    {
        public DayOfWeekEnum Day { get; set; }  // יום בשבוע
        public TimeSpan TimeOfDay { get; set; }  // שעה ודקה

        // בנאי של המחלקה Time - מקבל יום (Enum) ושעה ודקה
        public Time(DayOfWeekEnum day, int hour, int minute)
        {
            this.Day = day;
            this.TimeOfDay = new TimeSpan(hour, minute, 0);  // TimeSpan מקבל שעה, דקה ושנייה
        }
        public Time(DayOfWeekEnum day, TimeSpan timeOfSpan)
        {
            this.Day = day;
            this.TimeOfDay = new TimeSpan(timeOfSpan.Hours, timeOfSpan.Minutes, 0);  // TimeSpan מקבל שעה, דקה ושנייה
        }

        // אוברייד של ToString כדי להדפיס בצורה נוחה
        public override string ToString()
        {
            return $"{Day}: {TimeOfDay:hh\\:mm}";  // הדפסה ב- HH:mm
        }

        // פונקציה להשוואת שני אובייקטי זמן - לבדוק אם הם באותו יום ובאותה שעה
        public bool IsSameTime(Time other)
        {
            return this.Day == other.Day && this.TimeOfDay.Hours == other.TimeOfDay.Hours;
        }
    }
}
