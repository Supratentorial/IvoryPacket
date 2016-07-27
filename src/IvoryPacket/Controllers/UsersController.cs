using IvoryPacket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{
    public class UsersController : Controller
    {
        private IvoryPacketDbContext dbContext;

        public UsersController(IvoryPacketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/values
        [Route("api/users")]
        [HttpGet]
        public IActionResult GetUsers(string type)
        {
            var users = dbContext.Users.AsQueryable();
            if (!string.IsNullOrEmpty(type))
            {
                users = users.Where(u => u.Role == type);
            }

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
        public IActionResult Post([FromBody]User user)
        {
            if (!ModelState.IsValid || user == null || user.UserId != 0)
            {
                return BadRequest();
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return Ok(user);
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
