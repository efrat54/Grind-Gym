using Grind.Core.Dots;
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IConfiguration _configuration;
        public ClientsController(IClientService clientService, IConfiguration configuration)
        {
            _clientService = clientService;
            _configuration = configuration;
        }
        // GET: api/<Clients>
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            Console.WriteLine(_configuration["ApplicationName"]);
            List<ClientDTO> c = _clientService.GetClients();
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        // GET api/<Clients>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)

        {
            Client t = _clientService.GetSpecificClient(id);
            if (t == null) return NotFound("Client did not found");
            return Ok(t);
        }

        // POST api/<Clients>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Client c)
        {
            if (await _clientService.AddClientAsync(c))
                return Ok("Client added seccessfully");
            return NotFound("this id is already in system");
        }

        // PUT api/<Clients>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Client client)
        {
            if (await _clientService.UpdateClientAsync(client))
                return Ok("Client updated seccessfully");
            return NotFound("Client did not found");
        }
        // DELETE api/<Clients>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (await _clientService.DeleteClientAsync(id))

                return Ok("Client deleted seccessfully");
            return NotFound("Client did not found");
        }
    }
}
