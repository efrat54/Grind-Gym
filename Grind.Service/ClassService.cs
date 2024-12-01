
using Grind.Core.Entities;
using Grind.Core.Enums;

namespace Grind.Service
{
    public class ClassService
    {
        public IEnumerable<Class> GetClasses()
        {
            return _dataContext.ClassLst;
        }


        public Class GetSpecificClass(Time time, Core.Enums.GymClasses name)
        {
            return _dataContext.ClassLst.FirstOrDefault(c => (c.className == name && c.classTime.IsSameTime(time)));

        }


        public void AddClass(Class c)
        {
            _dataContext.ClassLst.Add(c);

        }


        public bool UpdateClass(Class c1)
        {
            int index = _dataContext.ClassLst.FindIndex(c => (c.className == c1.className && c.classTime.IsSameTime(c1.classTime)));
            if (index != -1)
            {
                _dataContext.ClassLst[index] = c1;
                return true;
            }
            return false;
        }

        public bool DeleteClass(Time time, GymClasses name)
        {
            int index = _dataContext.ClassLst.FindIndex(c => (c.className == name && c.classTime.IsSameTime(time)));
            if (index != -1)
            {
                _dataContext.ClassLst.RemoveAt(index);
                return true;
            }
            return false;
        }



    }
}
