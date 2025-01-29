
using AutoMapper;
using Grind.Core.Dots;
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Data;
using Microsoft.EntityFrameworkCore;

namespace Grind.Service
{ 
    public class ClientService: IClientService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ClientService(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public List<ClientDTO> GetClients()
        {
           var clients= _dataContext.ClientsLst.Include(c => c.Address).ToList();
            return _mapper.Map<List<ClientDTO>>(clients);
        }
        //איך עושים את האסינק בגט? הוא לא נותן לעשות אוואיט
        public Client GetSpecificClient(string id)
        {
            //int index = _dataContext.ClientsLst.ToList().FindIndex(t => t.Id == id);
            //if (index != -1)
            //{
            //    return _dataContext.ClientsLst.ToList()[index];
            //}
            //Item item = db.Items.Find(id).Include(i => i.Category).Include(i => i.Brand);
            Client c= _dataContext.ClientsLst.Include(c => c.Address).FirstOrDefault(c => c.Id == id); 
            if(c!=null)
                return _mapper.Map<Client>(c);
            return null;
        }
        public async Task<bool> AddClientAsync(Client c)
        {
            //if (_dataContext.ClientsLst.ToList().FindIndex(c1 => c1.Id == c.Id) == -1)
            if(_dataContext.ClientsLst.Find(c.Id)==null)
            {
                _dataContext.ClientsLst.Add(c);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateClientAsync(Client client)
        {
            var updatedClient = _dataContext.ClientsLst.Find(client.Id);
            if (updatedClient != null)
            {
                _dataContext.Entry(updatedClient).CurrentValues.SetValues(client);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
            //int index = _dataContext.ClientsLst.ToList().FindIndex(c => c.Id == client.Id);
            //if (index != -1)
            //{
            //    _dataContext.ClientsLst.ToList()[index] = client;
            //    return true;
            //}
            //return false;

        }
        public async Task<bool> DeleteClientAsync(string id)
        {
            var client = _dataContext.ClientsLst.Find(id);
            if (client != null)
            {
                _dataContext.ClientsLst.Remove(client);
               await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
            //int index = _dataContext.ClientsLst.ToList().FindIndex(c => c.Id == id);
            //if (index != -1)
            //{
            //    _dataContext.ClientsLst.ToList().RemoveAt(index);
            //    return true;
            //}
            //return false;
        }
    }
}
