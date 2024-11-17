using Grind.Enums;

namespace Grind.Entities
{
    public static class DataContext
    {
        public static List<Class> ClassLst { get; set; }
        public static List<Trainer> TrainersLst { get; set; }
        public static List<Client>ClientsLst { get; set; }
        static DataContext()
        {
            TrainersLst = new List<Trainer>(){new Trainer("123456789","Tova","lEVI",new Address("hadera","hanasi","30"),"0502222922",Enums.GymClasses.Zumba,50000)};
            TrainersLst.Add(new Trainer("987654321","Yael","Cohen", new Address("Jerusalem", "Yafo", "22"),"0502222922",Enums.GymClasses.Zumba,50000));
            ClassLst = new List<Class>(){new Class(GymClasses.Pilates, "Yael Cohen",new Time( DayOfWeekEnum.Monday, 16, 30), DifficultyLevel.Easy) };
            ClassLst.Add(new Class(GymClasses.Pilates,"Yael Cohen", new(DayOfWeekEnum.Monday,19,30), DifficultyLevel.Hard));
            ClientsLst = new List<Client>() { new Client("321654987","Rachel","Sharvit",new Address("Jerusalem","Sulam yaakov","34"),"0505050505")};
            ClientsLst.Add(new Client("987456312", "Efrat", "Hugi", new Address("Jerusalem", "Navon", "128"), "0404040404"));
        }
    }
}
