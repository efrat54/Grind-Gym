using Grind.Entities;
using Grind.Enums;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        // GET: api/<ClassesController>
        [HttpGet]
        public IEnumerable<Class> Get()
        {
            return DataContext.ClassLst;
        }

        // GET api/<ClassesController>/5
        [HttpGet("{class name}")]
        public string Get(GymClasses name)
        {
            var lesson = DataContext.ClassLst.FirstOrDefault(c=>c.className == name);
            if (lesson == null)
            {
                return "User not found";
            }
            return "value";
        }

        // POST api/<ClassesController>
        [HttpPost]
        public void Post([FromBody] Class c)
        {
            DataContext.ClassLst.Add(c);
        }

        // PUT api/<ClassesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Class c)
        {
        }

        // DELETE api/<ClassesController>/5
        [HttpDelete("{id}")]
        public void Delete(Class c)
        {
            DataContext.ClassLst.Remove(c);
        }

    }
}
