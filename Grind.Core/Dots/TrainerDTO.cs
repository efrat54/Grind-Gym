using Grind.Core.Entities;
using Grind.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Core.Dots
{
    public class TrainerDTO
    {
        public GymClasses expertise { get; set; }
        public double monthlySalary { get; set; }
        public Time[] classTimes { get; set; }
        public string firstName{ get; set; }
        public string lastName{ get; set; }
        public string phoneNumber{ get; set; }
        public string email{ get; set; }
    }
}
