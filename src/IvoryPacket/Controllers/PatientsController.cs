using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using IvoryPacket.Models;
using IvoryPacket.Filters;
using Microsoft.Data.Entity;
using System;

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
            return DbContext.Patients.Take(40);
        }

        // GET api/values/5
        [HttpGet("{patientId}")]
        public Patient Get(int patientId)
        {
            return DbContext.Patients
                .Where(p => p.PatientId == patientId)
                .Include(p => p.EmailAddress)
                .Include(p => p.PhoneNumbers)
                .FirstOrDefault();
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
        [HttpPut("{patientId}")]
        public IActionResult Put(int patientId, [FromBody]Patient patient)
        {
            DbContext.Entry(patient).State = patient.PatientId == 0 ? EntityState.Added : EntityState.Modified;
            DbContext.Entry(patient.EmailAddress).State = patient.EmailAddress.EmailAddressId == 0 ? EntityState.Added : EntityState.Modified;
            foreach (PhoneNumber phone in patient.PhoneNumbers) {
                DbContext.Entry(phone).State = phone.PhoneNumberId == 0 ? EntityState.Added : EntityState.Modified;
            }
            DbContext.SaveChanges();
            return new HttpOkObjectResult(patient);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
