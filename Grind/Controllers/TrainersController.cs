using Grind.Core.Dots;
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Grind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerConroller : ControllerBase
    {
        private readonly ITrainerService _TrainerService;
        public TrainerConroller(ITrainerService trainerService)
        {
            _TrainerService = trainerService;
        }
        // GET: api/<WorkersController>
        [HttpGet]
        public ActionResult<IEnumerable<Trainer>> Get()
        {
            List<TrainerDTO> trainersTmp = _TrainerService.GetTrainers();
            if (trainersTmp == null)
                return NotFound("Trainer did not found");
            return Ok(trainersTmp);


        }
        // GET api/<WorkersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            TrainerDTO t = _TrainerService.GetSpecificTrainer(id);
            if (t == null)
                return NotFound("not found");
            return Ok(t);
        }

        // POST api/<WorkersController>
        [HttpPost]
        public ActionResult Post([FromBody] Trainer t)
        {
            if (_TrainerService.AddTrainer(t))
                return Ok("Trained added seccessfully");
            return NotFound("this id is already in system");
        }

        // PUT api/<WorkersController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Trainer trainer)
        {
            if (_TrainerService.UpdateTrainer(trainer))
                return Ok("Trainer updated seccessfully");
            return NotFound("Trainer did not found");
        }
        // DELETE api/<WorkersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (_TrainerService.DeleteTrainer(id))
                return Ok("Trainer deleted seccesfully");
            return NotFound("Trainer did not found");
        }
    }
}
