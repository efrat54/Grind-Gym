using Grind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Core.Dots
{
    public class ClientDTO
    {
        public bool isActive { get; set; }
        public int monthlyPayment { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
    }
}
