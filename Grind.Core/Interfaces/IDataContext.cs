

using Grind.Core.Entities;

namespace Grind.Core.Interfaces
{
     public interface IDataContext
    {
        public /*static*/ List<Class> ClassLst { get; set; }
        public /*static*/ List<Trainer> TrainersLst { get; set; }
        public /*static*/ List<Client> ClientsLst { get; set; }
    }
}
