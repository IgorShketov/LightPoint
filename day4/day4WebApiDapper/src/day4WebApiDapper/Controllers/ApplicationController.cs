using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using day4WebApiDapper.Models;
using Dapper;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace day4WebApiDapper.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private const string ConnectionStringName = "UsersGroups";

        private readonly DataBaseConnectionProvider _connectionProvider;
        private readonly string _connectionString;

        public ApplicationController()
        {
            _connectionProvider = new DataBaseConnectionProvider();
            _connectionString = Startup.ConnectionString;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Application> Get()
        {
            IEnumerable<Application> result;

            using (var connection = _connectionProvider.GetConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<Application>("SELECT Id, Name, UserId FROM Applications");
                connection.Close();
            }

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
