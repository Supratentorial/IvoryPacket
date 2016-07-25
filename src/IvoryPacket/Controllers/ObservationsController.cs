using System.Collections.Generic;
using System.Linq;
using IvoryPacket.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{
    public class ObservationsController : Controller
    {
        
        public IvoryPacketDbContext DbContext { get; set; }

        public ObservationsController(IvoryPacketDbContext dbContext) {

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/patients/{patientId}/observations/smoking")]
        [HttpGet]
        public void GetSmokingObservation(int patientId)
        {
            if (patientId != 0) {
                var patient = DbContext.Patients.Single(p => p.PatientId == patientId);

            }
        }

        [Route("api/observations/smoking")]
        [HttpPost]
        public void PostSmokingObservation([FromBody]SmokingHistory smokingHistory)
        {
            
        }

        [Route("api/observations/alcohol")]
        [HttpPost]
        public void PostAlcoholObservation([FromBody]AlcoholHistory alcoholHistory) {

        }

        [Route("api/observations/vitals")]
        [HttpPost]
        public IActionResult PostVitalsObservation(int patientId, [FromBody]VitalSign vitalSign)
        {
            if (patientId == 0) {
                return new BadRequestResult();
            }
            if (vitalSign.VitalSignId != 0)
            {
                return new BadRequestResult();
            }

            var existingPatient = DbContext.Patients.Where(p => p.PatientId == patientId).SingleOrDefault();
            existingPatient.VitalSigns.Add(vitalSign);
            return Ok(existingPatient);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
