namespace Grind.Entities
{
    public static class DataContext
    {
        public static List<Class> ClassLst { get; set; }
        public static List<Trainer> TrainersLst { get; set; }
        public static List<Client>ClientsLst { get; set; }
        static DataContext()
        {
            TrainersLst = new List<Trainer>() { new Trainer("123456789", "Tova", "lEVI", new Address("hadera","hanasi","30") {apartmentNumber = "1",city = "BB", street = "Rabi Akiva"}, "0502222922",Enums.GymClasses.Zumba,50000 )  };
            ClassLst = new List<Class>();
            ClientsLst= new List<Client>();
           

        }
    }
}
