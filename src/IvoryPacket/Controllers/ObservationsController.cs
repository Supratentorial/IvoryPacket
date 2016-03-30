using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IvoryPacket.DTOs;
using IvoryPacket.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{
    public class ObservationsController : Controller
    {

        [FromServices]
        public IvoryPacketDbContext DbContext { get; set; }

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
        public void PostSmokingObservation([FromBody]SmokingDTO smokingDTO)
        {
            
        }

        [Route("api/observations/alcohol")]
        [HttpPost]
        public void PostAlcoholObservation([FromBody]AlcoholDTO alcoholDTO) {

        }

        [Route("api/observations/vitals")]
        [HttpPost]
        public void PostVitalsObservation(int id, [FromBody]VitalsDTO vitalsDTO)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
