using Grind.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        // GET: api/<WorkersController>
        [HttpGet]
        public IEnumerable<Trainer> Get()
        {
            return DataContext.TrainersLst;
        }

        // GET api/<WorkersController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var trainer = DataContext.TrainersLst.FirstOrDefault(t => t.Id == id);
            if (trainer == null)
            {
                return "User not found";
            }
            return "value";
        }

        // POST api/<WorkersController>
        [HttpPost]
        public void Post([FromBody] Trainer t)
        {
            DataContext.TrainersLst.Add(t);
        }

        // PUT api/<WorkersController>/5
        [HttpPut]
        public void Put([FromBody] Trainer trainer)
        {
            Trainer t = DataContext.TrainersLst.FirstOrDefault(f1 => f1.Id == trainer.Id);

            t = trainer;//לוודא שאכן משנה את הליסט 

        }

        // DELETE api/<WorkersController>/5
        [HttpDelete("{id}")]
        public void Delete(Trainer t)
        {
            DataContext.TrainersLst.Remove(t);
        }
    }
}
