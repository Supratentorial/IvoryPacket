using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using IvoryPacket.Models;
using IvoryPacket.Filters;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{
    [Route("api/patients")]
    public class PatientsController : Controller
    {
        [FromServices]
        public IvoryPacketDbContext DbContext { get; set; }

        // GET: api/patients
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return DbContext.Patients;
        }

        // GET api/values/5
        [HttpGet("{patientId}")]
        public Patient Get(int patientId)
        {
            return DbContext.Patients.Single(p => p.PatientId == patientId);
        }

        // POST api/patients
        [HttpPost]
        [ValidateModel]
        public IActionResult Post([FromBody]Patient patient)
        {
            DbContext.Add(patient);
            DbContext.SaveChanges();
            return new HttpOkObjectResult(patient);
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
