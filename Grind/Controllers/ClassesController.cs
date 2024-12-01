
using Grind.Core.Entities;
using Grind.Core.Interfaces;
using Grind.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Grind.Service;
using Class = Grind.Core.Entities.Class;

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        private readonly ClassService _classService;
        public ClassesController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Class>> Get()
        {
            Class c = _classService.GetClasses;
            if (c == null)
                return NotFound("Class did not found");
            return Ok(c);
        }

        [HttpGet("{class name}")]
        public ActionResult<Class> Get(Time time, GymClasses name)
        {
            Class lesson = _classService.GetSpecificClass(time, name);
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
            _classService.AddClass(c);
            return Ok("added seccessfully");
        }

        [HttpPut("{id}")]
        public ActionResult Put(Class c1)
        {
            if (_classService.UpdateClass(c1))
                return Ok("Class added seccessfully");
            return NotFound("Class did not found");
        }
        [HttpDelete()]
        public ActionResult Delete(Time time, GymClasses name)
        {
            if (_classService.DeleteClass(time, name))
                return Ok("Class deleted seccessfully");
            return NotFound("Class did not found");
        }


    }
}
