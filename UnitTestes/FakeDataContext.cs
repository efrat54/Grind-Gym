using Grind.Core.Entities;
using Grind.Core.Enums;
using Grind.Core.Interfaces;

namespace UnitTestes.Test
{
    public class FakeDataContext : IDataContext
    {
        public /*static*/ List<Class> ClassLst { get; set; }
        public /*static*/ List<Trainer> TrainersLst { get; set; }
        public/* static*/ List<Client> ClientsLst { get; set; }
        public /*static*/ FakeDataContext()
        {
            TrainersLst = new List<Trainer>() { new Trainer("123456789", "fake", "lEVI", new Address(2,"hadera", "hanasi", "30"), "0502222922", GymClasses.Zumba, 50000) };
            TrainersLst.Add(new Trainer("987654321", "Yael", "Cohen", new Address(1,"Jerusalem", "Yafo", "22"), "0502222922", GymClasses.Zumba, 50000));
            ClassLst = new List<Class>() { new Class(GymClasses.Pilates, "Yael Cohen", new Time(DayOfWeekEnum.Monday, 16, 30,2), DifficultyLevel.Easy,1) };
            ClassLst.Add(new Class(GymClasses.Pilates, "Yael Cohen", new(DayOfWeekEnum.Monday, 19, 30,1), DifficultyLevel.Hard,2));
            ClientsLst = new List<Client>() { new Client("321654987", "Rachel", "Sharvit", new Address(3,"Jerusalem", "Sulam yaakov", "34"), "0505050505") };
            ClientsLst.Add(new Client("987456312", "Efrat", "Hugi", new Address(4,"Jerusalem", "Navon", "128"), "0404040404"));
        }
    }
}
