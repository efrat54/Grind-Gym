using Grind.Core.Enums;
namespace Grind.Core.Entities
{
    public class Class
    {
        public GymClasses className { get;  set; }  // שם השיעור (אינאם GymClasses)
        public string trainerName { get;  set; }  // המדריך
        public string[] participants { get;  set; }  // מערך משתתפים
        public Time classTime { get;  set; }  // זמן השיעור
        public DifficultyLevel difficulty { get;  set; }  // רמת קושי השיעור
        public int numOfParticipants { get;  set; }
        public int cost { get;  set; }

        public Class(GymClasses className, string trainerName, Time classTime, DifficultyLevel difficulty)
        {
            this.className = className;
            this.trainerName = trainerName;
            this.classTime = classTime;
            this.difficulty = difficulty;
            participants = new string[20];  // אתחול מערך משתתפים בגודל 20
        }

        // מתודה להוספת משתתף
        public void AddParticipant(Client client)
        {
            for (int i = 0; i < participants.Length; i++)
            {
                if (participants[i] == null)
                {
                    participants[i] = client.Id;
                    numOfParticipants++;
                    client.monthlyPayment += this.cost;
                    Console.WriteLine("Client added successfully.");
                    return;
                }
                if (participants[i] == client.Id)
                    Console.WriteLine("This client is already in this class");
            }
            Console.WriteLine("The class is full.");
        }
        public void RemoveParticipant(Client client)
        {
            for(int i=0;i< participants.Length;i++)
            {
                if (participants[i] == client.Id)
                {
                    participants[i] = null;
                    numOfParticipants--;
                    client.monthlyPayment -= this.cost;
                    Console.WriteLine("The client removed seccessfully.");
                    return;
                }
            }
            Console.WriteLine("This client did not found.");
        }
    }
}
