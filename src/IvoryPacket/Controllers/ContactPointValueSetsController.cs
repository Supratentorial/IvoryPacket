using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{
    [Route("api/contactpoint/valuesets")]
    public class ContactPointValueSetsController : Controller
    {
        [Route("/systems")]
        [HttpGet]
        public IEnumerable<string> GetContactPointSystemOptions()
        {
            return new string[] { "Phone", "Fax", "Email", "Pager" };
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
