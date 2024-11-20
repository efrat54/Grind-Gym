using Grind.Entities;
using Grind.Enums;
using Grind.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class ClientsController : ControllerBase
    {




        private readonly IDataContext _dataContext;
        public ClientsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }



        // GET: api/<Clients>
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            if (_dataContext.ClientsLst == null)
                return NotFound();
            return Ok(_dataContext.ClientsLst);
        }

        // GET api/<Clients>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            int index = _dataContext.ClientsLst.FindIndex(t => t.Id == id);
            if (index == -1)
            {
                return NotFound("not found");
            }
            return Ok(_dataContext.ClientsLst[index]);
        }

        // POST api/<Clients>
        [HttpPost]
        public ActionResult Post([FromBody] Client c)
        {
            if (_dataContext.ClientsLst.FindIndex(c1 => c1.Id == c.Id) == -1)
            {
                _dataContext.ClientsLst.Add(c);
                return Ok();
            }
            return NotFound("this id is already in system");
        }

        // PUT api/<Clients>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Client client)
        {
            int index = _dataContext.ClientsLst.FindIndex(c => c.Id == client.Id);
            if (index == -1)
                return NotFound();
            _dataContext.ClientsLst[index] = client;
            return Ok();
        }

        // DELETE api/<Clients>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            int index= _dataContext.ClientsLst.FindIndex(c => c.Id == id);
            if(index == -1)
                return NotFound();
            _dataContext.ClientsLst.RemoveAt(index);
            return Ok();
        }
    }
}
