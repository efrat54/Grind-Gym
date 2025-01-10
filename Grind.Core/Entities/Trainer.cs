using Grind.Core.Enums;
namespace Grind.Core.Entities
{
    public class Trainer : Person
    {
        public GymClasses expertise { get; set; }  // תחום ההתמחות של המדריך
        public double monthlySalary { get; set; }  // שכר חודשי של המדריך
                                                   //public Time[] classTimes { get; set; }  // מערך של זמנים לשיעורים
        public List<Time> classTimes { get; set; } = new List<Time>();


        public Trainer(string id, string firstName, string lastName, Address address, string phoneNumber, GymClasses expertise, double monthlySalary)
            : base(id, firstName, lastName, address, phoneNumber)
        {
            this.expertise = expertise;
            this.monthlySalary = monthlySalary;
            //classTimes = new Time[5];  // אתחול מערך שיעורים בגודל 5
        }
        public Trainer() { }
        // אוברייד של המתודה ClassAdding
        public override void ClassAdding(Class classN)
        {
            if (classN.className != this.expertise)
            {
                Console.WriteLine("Cannot add this class. This class does not match your expertise in {this.expertise}.");
                return;
            }
            // עכשיו נבדוק אם הזמן של השיעור תואם לזמנים של שיעורים אחרים


            if (classTimes.Any(ct => ct.IsSameTime(classN.classTime)))
            {
                Console.WriteLine("Cannot add this class. Another class is scheduled at the same time.");
                return;
            }


            //// אם לא נמצאה בעיה עם הזמנים, נוסיף את השיעור
            //for (int i = 0; i < classTimes.Length; i++)
            //{
            //    if (classTimes[i] == null)
            //    {
            //        classTimes[i] = new Time(classN.classTime.Day, classN.classTime.hour, classN.classTime.minute, classN.classTime.id);  // הוספת הזמן לשיעור במערך
            //        this.monthlySalary += (classN.cost * classN.numOfParticipants) * 3 / 10;
            //        Console.WriteLine("Class added successfully.");
            //        return;
            //    }
            //}
            classTimes.Add(new Time(classN.classTime.Day, classN.classTime.hour, classN.classTime.minute, classN.classTime.id));
            this.monthlySalary += (classN.cost * classN.numOfParticipants) * 3 / 10;
            Console.WriteLine("Class added successfully.");
        }

        // אוברייד של המתודה ClassRemoving
        public override void ClassRemoving(Class classN)
        {
            //for (int i = 0; i < classTimes.Length; i++)
            //{
            //    if (classTimes[i] != null && classTimes[i].IsSameTime(classN.classTime))
            //    {
            //        classTimes[i] = null;  // מחיקת הזמן של השיעור
            //        Console.WriteLine("Class removed successfully.");
            //        return;
            //    }
            //}
            //Console.WriteLine("Class not found.");
            var timeToRemove = classTimes.FirstOrDefault(ct => ct.IsSameTime(classN.classTime));
            if (timeToRemove != null)
            {
                classTimes.Remove(timeToRemove); // מחיקת הזמן מהרשימה
                Console.WriteLine("Class removed successfully.");
            }
            else
            {
                Console.WriteLine("Class not found.");
            }
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
