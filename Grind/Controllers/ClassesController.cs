
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Grind.Service;
using Class = Grind.Core.Entities.Class;

namespace Grind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _ClassService;
        public ClassesController(IClassService ClassService)
        {
            _ClassService = ClassService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Class>> Get()
        {
            List<Class> c = _ClassService.GetClasses();
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        [HttpGet("{class name}")]
        public ActionResult<Class> Get(int id)
        {
            Class lesson = _ClassService.GetSpecificClass(id);
            if (lesson == null)
            {
                return NotFound("Class did not found");
            }
            return Ok(lesson);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Class c)
        {
            if (c == null)
                return NotFound();
            _ClassService.AddClass(c);
            return Ok("added seccessfully");
        }
       
        [HttpPut("{id}")]
        public ActionResult Put(Class c1)
        {
            if (_ClassService.UpdateClass(c1))
                return Ok("Class added seccessfully");
            return NotFound("Class did not found");
        }
        [HttpDelete()]
        public ActionResult Delete(int id)
        {
            if (_ClassService.DeleteClass(id))
                return Ok("Class deleted seccessfully");
            return NotFound("Class did not found");
        }


    }
}
