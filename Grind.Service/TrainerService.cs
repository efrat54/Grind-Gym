using AutoMapper;
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Data;
using Microsoft.EntityFrameworkCore;

namespace Grind.Service
{
    public class TrainerService: ITrainerService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public TrainerService(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public List<Trainer> GetTrainers()
        {
             var trainers=_dataContext.TrainersLst.Include(t => t.Address).ToList();
            return _mapper.Map<List<Trainer>>(trainers);
        }
        public Trainer GetSpecificTrainer(string id)
        {
           Trainer t= _dataContext.TrainersLst.Include(t => t.Address).FirstOrDefault(t=>t.Id==id);
             if(t!=null)
                return _mapper.Map<Trainer>(t);
            return null;
            //int index = _dataContext.TrainersLst.ToList().FindIndex(t => t.Id == id);
            //if (index != -1)
            //{
            //    return _dataContext.TrainersLst.ToList()[index];

            //}
            //return null;
        }
        public bool AddTrainer(Trainer t)
        {
            if (_dataContext.TrainersLst.Find(t.Id)==null)
            {
                _dataContext.TrainersLst.Add(t);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateTrainer(Trainer trainer)
        {
            var updatedTrainer= _dataContext.TrainersLst.Find(trainer.Id);
            if (updatedTrainer!=null)
            {
                _dataContext.Entry(updatedTrainer).CurrentValues.SetValues(trainer);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
            //int index = _dataContext.TrainersLst.ToList().FindIndex(c => c.Id == trainer.Id);
            //if (index != -1)
            //{
            //    _dataContext.TrainersLst.ToList()[index] = trainer;
            //    return true;
            //}
            //return false;
        }
        public bool DeleteTrainer(string id)
        {



            var relatedTimes = _dataContext.TimesLst.Where(t => t.trainerId == id).ToList();
            if (relatedTimes.Any())
            {
                _dataContext.TimesLst.RemoveRange(relatedTimes);
            }

            // מחיקת ה-Trainer עצמו
            var trainer = _dataContext.TrainersLst.Find(id);
            if (trainer != null)
            {
                _dataContext.TrainersLst.Remove(trainer);
                _dataContext.SaveChanges();
                return true;
            }

            return false;




            var t = _dataContext.TrainersLst.Find(id);
            if (t!=null)
            {
                _dataContext.TrainersLst.Remove(t);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
            //int index = _dataContext.TrainersLst.ToList().FindIndex(c => c.Id == id);
            //if (index != -1)
            //{
            //    _dataContext.TrainersLst.ToList().RemoveAt(index);
            //    return true;
            //}
            //return false;
        }
    }
}
