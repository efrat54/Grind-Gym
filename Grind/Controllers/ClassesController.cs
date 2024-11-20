using Grind.Entities;
using Grind.Enums;
using Grind.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {


        private readonly IDataContext _dataContext;
        public ClassesController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpGet]
        public ActionResult <IEnumerable<Class>> Get()
        {
            if(_dataContext.ClassLst==null)
                return NotFound();
            return Ok(_dataContext.ClassLst);
        }

        [HttpGet("{class name}")]
        public ActionResult <Class> Get(Time time, GymClasses name)
        {
            Class lesson = _dataContext.ClassLst.FirstOrDefault(c=>( c.className == name && c.classTime.IsSameTime(time)));
            if (lesson == null)
            {
                return NotFound("User not found");
            }
            return Ok(lesson);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Class c)
        {
            _dataContext.ClassLst.Add(c);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(Class c1)
        {
            int index = _dataContext.ClassLst.FindIndex(c => (c.className == c1.className && c.classTime.IsSameTime(c1.classTime)));
            if(index==-1)
                return NotFound();
            _dataContext.ClassLst[index]=c1;
            return Ok();
        }
        [HttpDelete()]
        public ActionResult Delete(Time time, GymClasses name)
        {
            int index = _dataContext.ClassLst.FindIndex(c => (c.className == name && c.classTime.IsSameTime(time)));

            if (index == -1)
                return NotFound("Id container not found");

            _dataContext.ClassLst.RemoveAt(index);
            return Ok();
        }
        

    }
}
