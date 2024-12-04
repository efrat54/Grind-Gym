using Grind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Core.Interfaces
{
    public interface ITrainerService
    {
        public List<Trainer> GetTrainers();
        public Trainer GetSpecificTrainer(string id);
        public bool AddTrainer(Trainer t);
        public bool UpdateTrainer(Trainer trainer);
        public bool DeleteTrainer(string id);
    }
}
