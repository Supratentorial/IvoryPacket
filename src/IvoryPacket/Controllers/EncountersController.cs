using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IvoryPacket.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{
    [Route("api/[controller]")]
    public class EncountersController : Controller
    {

        private IvoryPacketDbContext dbContext;

        public EncountersController(IvoryPacketDbContext dbContext) {
            this.dbContext = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetPastEncountersByPatientId(int patientId)
        {
            var patients = dbContext.Encounters.Select(e => e.PatientId == patientId);
            return new HttpOkObjectResult(patients);
        }

        // POST api/values
        [HttpPost]
        [Route("api/patient/{patientId}/encounters/{encounterId}")]
        public IActionResult Post([FromBody]Encounter encounter)
        {
            dbContext.Encounters.Add(encounter);
            dbContext.SaveChanges();
            return new HttpOkObjectResult(encounter);
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
