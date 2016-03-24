using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using IvoryPacket.Models;
using IvoryPacket.Filters;
using Microsoft.Data.Entity;
using IvoryPacket.DTOs;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{

    public class PatientsController : Controller
    {
        [FromServices]
        public IvoryPacketDbContext DbContext { get; set; }

        [Route("api/patients")]
        // GET: api/patients
        [HttpGet]
        public IActionResult Get()
        {
            var patients = DbContext.Patients.Take(40);
            List<PatientSimpleDTO> patientDTOs = new List<PatientSimpleDTO>();
            foreach (Patient patient in patients)
            {
                var patientDTO = new PatientSimpleDTO()
                {
                    PatientId = patient.PatientId,
                    GivenName = patient.GivenName,
                    FamilyName = patient.FamilyName,
                    DateOfBirth = patient.DateOfBirth,
                    Gender = patient.Gender,
                    Age = patient.GetAgeString(),
                    FullName = patient.GetFullName(),
                    IsActive = patient.IsActive,
                    PreferredName = patient.PreferredName,
                    Title = patient.Title
                };
                patientDTOs.Add(patientDTO);
            }
            return new HttpOkObjectResult(patientDTOs);
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/patients/{patientId}/detailed")]
        public PatientDetailedDTO GetDetailedPatient(int patientId)
        {
            var patient = DbContext.Patients
                .Where(p => p.PatientId == patientId)
                .Include(p => p.EmailAddress)
                .Include(p => p.PhoneNumbers)
                .FirstOrDefault();

            return new PatientDetailedDTO()
            {
                PatientId = patient.PatientId,
                Title = patient.Title,
                GivenName = patient.GivenName,
                FamilyName = patient.FamilyName,
                MiddleNames = patient.MiddleNames,
                FullName = patient.GetFullName(),
                PreferredName = patient.PreferredName,
                Age = patient.GetAgeString(),
                DateOfBirth = patient.DateOfBirth,
                EmailAddress = patient.EmailAddress,
                IsActive = patient.IsActive,
                Gender = patient.Gender,
                Allergies = patient.Allergies,
                Ethnicity = patient.Ethnicity,
                MedicareCardExpiry = patient.MedicareCardExpiry,
                MedicareCardNumber = patient.MedicareCardNumber,
                MedicareCardPosition = patient.MedicareCardPosition
            };
        }

        [HttpGet]
        [Route("api/patients/{patientId}/simple")]
        public PatientSimpleDTO GetSimplePatient(int patientId)
        {
            var patient = DbContext.Patients.Where(p => p.PatientId == patientId).FirstOrDefault();
            return new PatientSimpleDTO()
            {
                PatientId = patient.PatientId,
                GivenName = patient.GivenName,
                FamilyName = patient.FamilyName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Age = patient.GetAgeString(),
                FullName = patient.GetFullName(),
                IsActive = patient.IsActive,
                PreferredName = patient.PreferredName,
                Title = patient.Title
            };
        }

        // POST api/patients
        [HttpPost]
        [ValidateModel]
        [Route("api/patients/{patientId}/detailed")]
        public IActionResult Post([FromBody]PatientDetailedDTO patientDTO)
        {

            var patient = new Patient()
            {
                PatientId = patientDTO.PatientId,
                Title = patientDTO.Title,
                GivenName = patientDTO.GivenName,
                MiddleNames = patientDTO.MiddleNames,
                
                IsActive = patientDTO.IsActive,
                

            };
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
            foreach (PhoneNumber phone in patient.PhoneNumbers)
            {
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
