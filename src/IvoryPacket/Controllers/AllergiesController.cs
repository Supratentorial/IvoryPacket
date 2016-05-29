using System;
using System.Linq;
using IvoryPacket.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{

    public class AllergiesController : Controller
    {

        private IvoryPacketDbContext dbContext;
        private ILogger<AllergiesController> logger;

        public AllergiesController(IvoryPacketDbContext dbContext, ILogger<AllergiesController> logger) {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        [Route("api/patients/{patientId}/allergies")]
        public IActionResult GetAllergiesByPatientId(int patientId) {
            var allergies = dbContext.Allergies.Where(a => a.PatientId == patientId);
            return Ok(allergies);
        }

        [Route("api/patients/{patientId}/allergies/{allergyId}")]
        [HttpGet]
        public IActionResult GetAllergyById(int allergyId) {
            var allergy = dbContext.Allergies.SingleOrDefault(a => a.AllergyId == allergyId);
            return Ok(allergy);
        }

        [Route("api/patients/{patientId}/allergies")]
        [HttpPost]
        public IActionResult Post([FromBody]Allergy allergy)
        {
            if (allergy.AllergyId != 0) {
                return BadRequest();
            }
            if (allergy.PatientId == 0) {
                return BadRequest();
            }
            try
            {
                var patient = dbContext.Patients.SingleOrDefault(p => p.PatientId == allergy.PatientId);
                if (patient == null) {
                    return NotFound();
                }
                dbContext.Allergies.Add(allergy);
                dbContext.SaveChanges();
                return Ok(allergy);
            }
            catch (Exception exception) {
                logger.LogInformation(exception.Message);
                return BadRequest();
            }
        }

        // PUT api/values/5
        [Route("api/patients/{patientId}/allergies/{allergyId}")]
        [HttpPut]
        public IActionResult Put([FromRoute]int allergyId, [FromBody]Allergy allergy)
        {
            this.logger.LogInformation("Allergy ID is " + allergy.AllergyId);
            if (allergy.AllergyId == 0) {
                return BadRequest();
            }
            dbContext.Entry(allergy).State = EntityState.Modified;
            dbContext.SaveChanges();
            return Ok(allergy);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
