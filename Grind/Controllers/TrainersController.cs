using Grind.Entities;
using Grind.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {


        private readonly IDataContext _dataContext;
        public TrainersController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }





        // GET: api/<WorkersController>
        [HttpGet]
        public ActionResult<IEnumerable<Trainer>> Get()
        {
            if (_dataContext.TrainersLst == null)
                return NotFound();
            return Ok(_dataContext.TrainersLst);
        }

        // GET api/<WorkersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            int index= _dataContext.TrainersLst.FindIndex(t => t.Id == id);
            if (index==-1)
            {
                return NotFound("not found");
            }
            return Ok(_dataContext.TrainersLst[index]);
        }

        // POST api/<WorkersController>
        [HttpPost]
        public ActionResult Post([FromBody] Trainer t)
        {
            if (_dataContext.TrainersLst.FindIndex(t1 => t1.Id == t.Id) == -1)
            {
                _dataContext.TrainersLst.Add(t);
                return Ok();
            }return NotFound("this id is already in system");
        }

        // PUT api/<WorkersController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Trainer trainer)
        {
            int index = _dataContext.TrainersLst.FindIndex(c => c.Id == trainer.Id);
            if (index == -1)
                return NotFound();
            _dataContext.TrainersLst[index] = trainer;
            return Ok();
        }
        // DELETE api/<WorkersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            int index = _dataContext.TrainersLst.FindIndex(c => c.Id == id);
            if (index == -1)
                return NotFound();
            _dataContext.TrainersLst.RemoveAt(index);
            return Ok();
        }
    }
}
