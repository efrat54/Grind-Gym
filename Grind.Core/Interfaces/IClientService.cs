using Grind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Core.Interfaces
{
    public interface IClientService
    {
        public List<Client> GetClients();
        public Client GetSpecificClient(string id);
        public bool AddClient(Client c);
        public bool UpdateClient(Client client);
        public bool DeleteClient(string id);
    }
}
