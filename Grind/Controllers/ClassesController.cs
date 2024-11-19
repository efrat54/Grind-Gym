using Grind.Entities;
using Grind.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Grind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Class> Get()
        {
            return DataContext.ClassLst;
        }

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

        [HttpPost]
        public void Post([FromBody] Class c)
        {
            DataContext.ClassLst.Add(c);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Class c)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(Class c)
        {
            DataContext.ClassLst.Remove(c);
        }

    }
}
