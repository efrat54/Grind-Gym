using Grind.Core.Dots;
using Grind.Core.Entities;

namespace Grind.Core.Interfaces
{
    public interface IClientService
    {
        public List<ClientDTO> GetClients();
        public Client GetSpecificClient(string id);
        public Task<bool>AddClientAsync(Client c);
        public Task<bool> UpdateClientAsync(Client client);
        public Task<bool> DeleteClientAsync(string id);
    }
}
