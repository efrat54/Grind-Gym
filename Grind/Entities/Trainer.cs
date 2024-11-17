using Grind.Enums;

namespace Grind.Entities
{
    public class Trainer : Person
    {
        public GymClasses expertise { get;  set; }  // תחום ההתמחות של המדריך
        public decimal monthlySalary { get;  set; }  // שכר חודשי של המדריך
        public Time[] classTimes { get; set; }  // מערך של זמנים לשיעורים

        public Trainer(string id, string firstName, string lastName, Address address, string phoneNumber, GymClasses expertise, decimal monthlySalary)
            : base(id, firstName, lastName, address, phoneNumber)
        {
            this.expertise = expertise;
            this.monthlySalary = monthlySalary;
            classTimes = new Time[5];  // אתחול מערך שיעורים בגודל 5
        }

        // אוברייד של המתודה ClassAdding
        public override void ClassAdding(Class classN)
        {
            if (classN.className != this.expertise)
            {
                Console.WriteLine("Cannot add this class. This class does not match your expertise in {this.expertise}.");
                return;
            }
            // עכשיו נבדוק אם הזמן של השיעור תואם לזמנים של שיעורים אחרים
            for (int i = 0; i < classTimes.Length; i++)
            {
                if (classTimes[i] != null && classTimes[i].IsSameTime(classN.classTime))
                {
                    Console.WriteLine("Cannot add this class. Another class is scheduled at the same time.");
                    return;
                }
            }

            // אם לא נמצאה בעיה עם הזמנים, נוסיף את השיעור
            for (int i = 0; i < classTimes.Length; i++)
            {
                if (classTimes[i] == null)
                {
                    classTimes[i] = new Time(classN.classTime.Day,classN.classTime.TimeOfDay);  // הוספת הזמן לשיעור במערך
                    this.monthlySalary += (classN.cost* classN.numOfParticipants)*3/10;
                    Console.WriteLine("Class added successfully.");
                    return;
                }
            }

            Console.WriteLine("Cannot add more classes. Maximum classes reached.");
        }

        // אוברייד של המתודה ClassRemoving
        public override void ClassRemoving(Class classN)
        {
            for (int i = 0; i < classTimes.Length; i++)
            {
                if (classTimes[i] != null && classTimes[i].IsSameTime(classN.classTime))
                {
                    classTimes[i] = null;  // מחיקת הזמן של השיעור
                    Console.WriteLine("Class removed successfully.");
                    return;
                }
            }
            Console.WriteLine("Class not found.");
        }

        // אוברייד של ToString
        public override string ToString()
        {
            return base.ToString() +
                   $"\nExpertise: {expertise}" +
                   $"\nMonthly Salary: {monthlySalary:C}";
        }
    }
}
