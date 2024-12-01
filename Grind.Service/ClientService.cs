
using Grind.Core.Entities;

namespace Grind.Service
{
    public class ClientService
    {
        public List<Client> GetClients()
        {
            return _dataContext.ClientsLst;
        }
        public Client GetSpecificClient(string id)
        {
            int index = _dataContext.ClientsLst.FindIndex(t => t.Id == id);
            if (index != -1)
            {
                return _dataContext.ClientsLst[index];
            }
            return null;
        }
        public bool AddClient(Client c)
        {
            if (_dataContext.ClientsLst.FindIndex(c1 => c1.Id == c.Id) == -1)
            {
                _dataContext.ClientsLst.Add(c);
                return true;
            }
            return false;
        }

        public bool UpdateClient(Client client)
        {
            int index = _dataContext.ClientsLst.FindIndex(c => c.Id == client.Id);
            if (index != -1)
            {
                _dataContext.ClientsLst[index] = client;
                return true;
            }
            return false;
        }

        public bool DeleteClient(string id)
        {
            int index = _dataContext.ClientsLst.FindIndex(c => c.Id == id);
            if (index != -1)
            {
                _dataContext.ClientsLst.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
