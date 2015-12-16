using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using IvoryPacket.Models;
using System;

namespace IvoryPacket.Controllers
{
    public class AllergiesControllers : Controller
    {
        [FromServices]
        public IvoryPacketDbContext DbContext { get; set; }

        // GET api/allergies
        [Route("api/allergies")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Allergy1", "Allergy2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/allergies
        [Route("api/allergies")]
        [HttpPost]
        public IActionResult Post([FromBody]Allergy allergy)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest();
            }
            if(allergy.AllergyId != 0)
            {
                return HttpBadRequest();
            }
            DbContext.Add(allergy);
            return new ObjectResult(DbContext.Patients.;
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
