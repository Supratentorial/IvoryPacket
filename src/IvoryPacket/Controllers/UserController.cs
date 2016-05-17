using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IvoryPacket.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{
    public class UserController : Controller
    {
        private IvoryPacketDbContext dbContext;

        public UserController(IvoryPacketDbContext dbContext) {
            this.dbContext = dbContext;
        }

        // GET: api/values
        [Route("api/users")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            this.dbContext.Users.Add()
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
