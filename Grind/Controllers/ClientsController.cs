using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientsController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        private readonly ClientService _cientService;

        public ClientsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<Clients>
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            List<Client> c = _cientService.GetClients();
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        // GET api/<Clients>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            Client t = _cientService.GetSpecificClient(id);
            if (t == null) return NotFound("Client did not found");
            return Ok(t);
        }

        // POST api/<Clients>
        [HttpPost]
        public ActionResult Post([FromBody] Client c)
        {
            if (_cientService.AddClient(c))
                return Ok("Client added seccessfully");
            return NotFound("this id is already in system");
        }

        // PUT api/<Clients>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Client client)
        {
            if (_cientService.AddClient(client))
                return Ok("Client updated seccessfully");
            return NotFound("Client did not found");
        }
        // DELETE api/<Clients>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (_cientService.DeleteClient(id))

                return Ok("Client deleted seccessfully");
            return NotFound("Client did not found");
        }
    }
}
