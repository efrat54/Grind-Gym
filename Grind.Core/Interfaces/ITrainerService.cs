using Grind.Core.Dots;
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
        public List<TrainerDTO> GetTrainers();
        public TrainerDTO GetSpecificTrainer(string id);
        public bool AddTrainer(Trainer t);
        public bool UpdateTrainer(Trainer trainer);
        public bool DeleteTrainer(string id);
    }
}
