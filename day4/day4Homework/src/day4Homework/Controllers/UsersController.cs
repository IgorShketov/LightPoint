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
    public class UsersController : Controller
    {
        private UsersContext _context;
        public UsersController(UsersContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.First(X => X.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User newUser)
        {
            if (_context.Users.Any(X => X.Id == id))
            {
                newUser.Id = id;
                _context.Update(newUser);
                _context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var UserToDelete = _context.Users.SingleOrDefault(X => X.Id == id);
            if (UserToDelete != null)
            {
                UserToDelete.UserApps.ToList().ForEach(X => new ApplicationController(_context).Delete(X.Id));
                _context.Users.Remove(UserToDelete);
                _context.SaveChanges();
            }
        }
    }
}
