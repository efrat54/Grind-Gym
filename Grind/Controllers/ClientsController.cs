using Grind.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        // GET: api/<Clients>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return DataContext.ClientsLst;
        }

        // GET api/<Clients>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var client = DataContext.ClientsLst.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return "User not found";
            }
            return "value";
        }

        // POST api/<Clients>
        [HttpPost]
        public void Post([FromBody] Client c)
        {
            DataContext.ClientsLst.Add(c);
        }

        // PUT api/<Clients>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Client client)
        {
            Client c = DataContext.ClientsLst.FirstOrDefault(c1 => c1.Id == client.Id);

            c = client;
        }

        // DELETE api/<Clients>/5
        [HttpDelete("{id}")]
        public void Delete(Client c)
        {
            DataContext.ClientsLst.Remove(c);
        }
    }
}
