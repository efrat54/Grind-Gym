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
        [HttpPut]
        public void Put([FromBody] Trainer trainer)
        {
            // חפש את המדריך לפי המזהה
            var existingTrainer = DataContext.TrainersLst.FirstOrDefault(f1 => f1.Id == trainer.Id);

            if (existingTrainer != null)
            {
                // עדכן את המדריך
                existingTrainer.FirstName = trainer.FirstName;
                existingTrainer.LastName = trainer.LastName;
                existingTrainer.Address = trainer.Address;
                existingTrainer.PhoneNumber = trainer.PhoneNumber;
                existingTrainer.Email = trainer.Email;
                existingTrainer.monthlySalary = trainer.monthlySalary; // עדכון שכר חודשי אם נדרש
                existingTrainer.expertise = trainer.expertise; // ודא שכולל גם את תחום ההתמחות
                                                               // אם יש פרמטרים נוספים, עדכן אותם פה
            }
        }


        // DELETE api/<WorkersController>/5
        [HttpDelete("{id}")]
        public void Delete(Trainer t)
        {
            DataContext.TrainersLst.Remove(t);
        }
    }
}
