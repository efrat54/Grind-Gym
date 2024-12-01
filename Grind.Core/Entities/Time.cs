using Grind.Core.Enums;
namespace Grind.Core.Entities
{
    public class Time
    {
        public DayOfWeekEnum Day { get; set; }  // יום בשבוע
        //public TimeSpan TimeOfDay { get; set; }  // שעה ודקה
        public int hour {  get; set; }
        public int minute { get; set; }

        // בנאי של המחלקה Time - מקבל יום (Enum) ושעה ודקה
        public Time(DayOfWeekEnum day, int hour, int minute)
        {
            this.Day = day;
            this.hour = hour;
            this.minute = minute;        }


        // אוברייד של ToString כדי להדפיס בצורה נוחה
        public override string ToString()
        {
            return Day+"hour: "+hour+":"+minute;  // הדפסה ב- HH:mm
        }

        // פונקציה להשוואת שני אובייקטי זמן - לבדוק אם הם באותו יום ובאותה שעה
        public bool IsSameTime(Time other)
        {
            return this.Day == other.Day && this.hour== other.hour&&this.minute==other.minute;
        }
    }
}
