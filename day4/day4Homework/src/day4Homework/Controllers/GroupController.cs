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
    public class GroupController : Controller
    {
        private UsersContext _context;
        public GroupController(UsersContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return _context.Groups.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Group Get(int id)
        {
            return _context.Groups.First(X => X.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Group newGroup)
        {
            _context.Groups.Add(newGroup);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Group newGroup)
        {
            if (_context.Groups.Any(X => X.Id == id))
            {
                newGroup.Id = id;
                _context.Update(newGroup);
                _context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var GroupToDelete = _context.Groups.SingleOrDefault(X => X.Id == id);
            if (GroupToDelete != null)
            {
                GroupToDelete.Users.ToList().ForEach(X => new UsersController(_context).Delete(X.Id));
                _context.Groups.Remove(GroupToDelete);
                _context.SaveChanges();
            }
        }
    }
}
