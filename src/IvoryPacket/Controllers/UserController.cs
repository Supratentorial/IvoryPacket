using IvoryPacket.Models;
using Microsoft.AspNetCore.Mvc;

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
            var users = dbContext.Users;
            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/users")]
        [HttpPost]
        public void Post([FromBody]User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();   
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
