using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Data;

namespace Grind.Service
{
    public class TrainerService: ITrainerService
    {
        private readonly DataContext _dataContext;
        public TrainerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Trainer> GetTrainers()
        {
            return _dataContext.TrainersLst.ToList();
        }
        public Trainer GetSpecificTrainer(string id)
        {
            int index = _dataContext.TrainersLst.ToList().FindIndex(t => t.Id == id);
            if (index != -1)
            {
                return _dataContext.TrainersLst.ToList()[index];

            }
            return null;
        }
        public bool AddTrainer(Trainer t)
        {
            if (_dataContext.TrainersLst.ToList().FindIndex(t1 => t1.Id == t.Id) == -1)
            {
                _dataContext.TrainersLst.Add(t);
                return true;
            }
            return false;
        }
        public bool UpdateTrainer(Trainer trainer)
        {
            int index = _dataContext.TrainersLst.ToList().FindIndex(c => c.Id == trainer.Id);
            if (index != -1)
            {
                _dataContext.TrainersLst.ToList()[index] = trainer;
                return true;
            }
            return false;
        }
        public bool DeleteTrainer(string id)
        {
            int index = _dataContext.TrainersLst.ToList().FindIndex(c => c.Id == id);
            if (index != -1)
            {
                _dataContext.TrainersLst.ToList().RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
