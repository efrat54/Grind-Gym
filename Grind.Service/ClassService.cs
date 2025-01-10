
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Data;
namespace Grind.Service
{
    public class ClassService : IClassService
    {
        private readonly DataContext _dataContext;
        public ClassService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Class> GetClasses()
        {
            return _dataContext.ClassLst.ToList();
        }
        public Class GetSpecificClass(int id)
        {
            return _dataContext.ClassLst.Find(id);
        }
        public void AddClass(Class c)
        {
            _dataContext.ClassLst.Add(c);
            _dataContext.SaveChanges();
        }
        public bool UpdateClass(Class c1)
        {
            var updatedClass= _dataContext.ClassLst.Find(c1.Id);
            if (updatedClass != null)
            {
                _dataContext.Entry(updatedClass).CurrentValues.SetValues(c1);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
            //int index = _dataContext.ClassLst.ToList().FindIndex(c => c.Id==c1.Id);
            //if (index != -1)
            //{
            //    _dataContext.ClassLst.ToList()[index] = c1;
            //    return true;
            //}
            //return false;
        }
        public bool DeleteClass(int id)
        {
            var c = _dataContext.ClassLst.Find(id);
            if (c != null)
            {
                _dataContext.ClassLst.Remove(c);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
            //int index = _dataContext.ClassLst.ToList().FindIndex(c => c.Id==id);
            //if (index != -1)
            //{
            //    _dataContext.ClassLst.ToList().RemoveAt(index);
            //    return true;
            //}
            //return false;
        }
    }
}
