using Grind.Enums;

namespace Grind.Entities
{
    public class Client : Person
    {
        public bool isActive { get; set; }
        public int monthlyPayment;// מנוי פעיל או מוקפא

        // בנאי של Client
        public Client(string id, string firstName, string lastName, Address address, string phoneNumber)
            : base(id, firstName, lastName, address, phoneNumber)
        {
            isActive = true;  // מנוי פעיל ברירת מחדל
        }

        // אוברייד למתודה ClassAdding - אם המנוי מוקפא, לא ניתן להוסיף שיעורים
        public override void ClassAdding(Class classN)
        {
            if (!isActive)
            {
                Console.WriteLine("You cannot add classes because your subscription is frozen.");
                return;
            }
            base.ClassAdding(classN);  // קריאה למתודה של Person
        }

        // אוברייד למתודה ClassRemoving - אם המנוי מוקפא, לא ניתן להסיר שיעורים
        public override void ClassRemoving(Class classN)
        {
            if (!isActive)
            {
                Console.WriteLine("You cannot remove classes because your subscription is frozen.");
                return;
            }
            base.ClassRemoving(classN);  // קריאה למתודה של Person
        }

        // מתודה להקפאת המנוי
        public void FreezeSubscription()
        {
            isActive = false;
            Console.WriteLine("Your subscription has been frozen.");
        }

        // מתודה לשחרור המנוי
        public void ActivateSubscription()
        {
            isActive = true;
            Console.WriteLine("Your subscription has been activated.");
        }

        // אוברייד של ToString - מציג גם את מצב המנוי
        public override string ToString()
        {
            return base.ToString() +
                   $"\nSubscription Status: {(isActive ? "Active" : "Frozen")}";
        }
    }
}
