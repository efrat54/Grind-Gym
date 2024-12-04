using Grind.Core.Entities;
using Grind.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Core.Interfaces
{
    public interface IClassService
    {
        public List<Class> GetClasses();
        public Class GetSpecificClass(Time time, Core.Enums.GymClasses name);
        public void AddClass(Class c);
        public bool UpdateClass(Class c1);
        public bool DeleteClass(Time time, GymClasses name);
    }
}
