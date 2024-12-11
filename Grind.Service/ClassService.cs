
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

            return _dataContext.ClassLst.FirstOrDefault(c => c.Id == id );

        }
        public void AddClass(Class c)
        {
            _dataContext.ClassLst.Add(c);
        }
        public bool UpdateClass(Class c1)
        {
            int index = _dataContext.ClassLst.ToList().FindIndex(c => c.Id==c1.Id);
            if (index != -1)
            {
                _dataContext.ClassLst.ToList()[index] = c1;
                return true;
            }
            return false;
        }
        public bool DeleteClass(int id)
        {
            int index = _dataContext.ClassLst.ToList().FindIndex(c => c.Id==id);
            if (index != -1)
            {
                _dataContext.ClassLst.ToList().RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
