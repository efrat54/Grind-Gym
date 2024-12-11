
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Data;

namespace Grind.Service
{
    public class ClientService: IClientService
    {
        private readonly DataContext _dataContext;
        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Client> GetClients()
        {
            return _dataContext.ClientsLst.ToList();
        }
        public Client GetSpecificClient(string id)
        {
            int index = _dataContext.ClientsLst.ToList().FindIndex(t => t.Id == id);
            if (index != -1)
            {
                return _dataContext.ClientsLst.ToList()[index];
            }
            return null;
        }
        public bool AddClient(Client c)
        {
            if (_dataContext.ClientsLst.ToList().FindIndex(c1 => c1.Id == c.Id) == -1)
            {
                _dataContext.ClientsLst.Add(c);
                return true;
            }
            return false;
        }
        public bool UpdateClient(Client client)
        {
            int index = _dataContext.ClientsLst.ToList().FindIndex(c => c.Id == client.Id);
            if (index != -1)
            {
                _dataContext.ClientsLst.ToList()[index] = client;
                return true;
            }
            return false;
        }
        public bool DeleteClient(string id)
        {
            int index = _dataContext.ClientsLst.ToList().FindIndex(c => c.Id == id);
            if (index != -1)
            {
                _dataContext.ClientsLst.ToList().RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
