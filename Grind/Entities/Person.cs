using Grind.Enums;

namespace Grind.Entities
{
    public class Person
    {
        // מאפיינים פרטיים (private) להגנה על המידע
        private string id;
        private string firstName;
        private string lastName;
        private Address address;
        private string phoneNumber;
        private string email;

        // המערך של השיעורים שנבחרו
        protected Class[] chosenClasses;  // מערך שיעורים
        protected int numOfClasses;            // מספר שיעורים שנבחרו

        //בדיקה שהתז תקין
        public string Id
        {
            get { return id; }
            set
            {
                if (value.Length != 9 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("ID must be exactly 9 digits.");
                }
                id = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        //בדיקה שהכתובת תקינה
        public Address Address
        {
            get { return address; }
            set
            {
                if (value == null ||
                    string.IsNullOrEmpty(value.city) ||
                    string.IsNullOrEmpty(value.street) ||
                    string.IsNullOrEmpty(value.apartmentNumber))
                {
                    throw new ArgumentException("Address fields cannot be empty.");
                }
                address = value;
            }
        }
        //בדיקה שהטלפון תקין
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value.Length != 10 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("Phone number must be exactly 10 digits.");
                }
                phoneNumber = value;
            }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // בנאי של Person (המכיל את כל המאפיינים)
        public Person(string id, string firstName, string lastName, Address address, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            chosenClasses = new Class[5];  // אתחול מערך שיעורים בגודל 5
            numOfClasses = 0;
        }

        // מתודות הוספה והסרה של שיעורים (תמיכה במנגנון של הוספת שיעורים ללקוח/מאמן)
        public virtual void ClassAdding(Class classN)
        {
            if (numOfClasses == 5)
            {
                Console.WriteLine("You have reached the maximum number of classes.");
                return;
            }
            if (!chosenClasses.Contains(classN))
            {
                chosenClasses[numOfClasses] = classN;
                numOfClasses++;

                Console.WriteLine("The class was added successfully.");
            }
            else
            {
                Console.WriteLine("This class is already added.");
            }
        }

        public virtual void ClassRemoving(Class classN)
        {
            bool flag = false;
            for (int i = 0; i < numOfClasses; i++)
            {
                if (chosenClasses[i] == classN)
                {
                    flag = true;
                    for (int j = i; j < numOfClasses - 1; j++)
                    {
                        chosenClasses[j] = chosenClasses[j + 1];
                    }
                    numOfClasses--;
                    Console.WriteLine("The class was removed successfully.");
                    return;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Class not found.");
            }
        }

        // אוברייד של ToString
        public override string ToString()
        {
            string classList = string.Join(", ", chosenClasses.Where(c => c != null).Select(c => c.ToString()));  // התעלמות מאלמנטים ברירת מחדל
            return $"ID: {Id}\nName: {FirstName} {LastName}\nPhone: {PhoneNumber}\nEmail: {Email}\nAddress: {Address}\nClasses: {classList}";
        }
    }
}
