using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using day4Homework.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace day4Homework.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        // GET: api/values

        private UsersContext _context;
        public ApplicationController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Application> Get()
        {
            return _context.Applications.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Application Get(int id)
        {
            return _context.Applications.First(X => X.Id == id);
        } 

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Application value)
        {
            _context.Applications.Add(value);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Application newApp)
        {
            if(_context.Applications.Any(X => X.Id == id))
            {
                newApp.Id = id;
                _context.Update(newApp);
                _context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ApplicationToDelete = _context.Applications.SingleOrDefault(X => X.Id == id);

            if(ApplicationToDelete != null)
            {
                _context.Applications.Remove(ApplicationToDelete);
                _context.SaveChanges();
            }
        }
    }
}
