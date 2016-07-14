using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using day5Homework.Models;
using day5Homework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace day5Homework.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private ApplicationContext _context;
        public ApplicationController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("api/Applications")]
        public IEnumerable<Application> Get()
        {
            return _context.Applications.ToList();
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("api/Applications/{id}")]
        public Application Get(int id)
        {
            return _context.Applications.First(X => X.Id == id);
        }

        // POST api/values
        [Authorize]
        [HttpPost("api/Applications/Add")]
        public void Post([FromBody]Application value)
        {
            var userId = _userManager.GetUserId(Request.HttpContext.User);

            _context.Users.First(X => X.Id == userId).UserApps.Add(value);

            _context.Applications.Add(value);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("api/Applications/Update/{id}")]
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
        [Authorize]
        [HttpDelete("api/Applications/Remove/{id}")]
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
