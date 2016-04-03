using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using IvoryPacket.Models;
using IvoryPacket.Filters;
using Microsoft.Data.Entity;
using IvoryPacket.DTOs;
using System;

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

            var patientDTO = new PatientDetailedDTO();
            patientDTO.PatientId = patient.PatientId;
            patientDTO.Title = patient.Title;
            patientDTO.GivenName = patient.GivenName;
            patientDTO.FamilyName = patient.FamilyName;
            patientDTO.MiddleNames = patient.MiddleNames;
            patientDTO.FullName = patient.GetFullName();
            patientDTO.PreferredName = patient.PreferredName;
            patientDTO.Age = patient.GetAgeString();
            patientDTO.DateOfBirth = patient.DateOfBirth;
            patientDTO.EmailAddress = patient.EmailAddress;
            patientDTO.MobilePhoneNumber = patient.PhoneNumbers.Where(p => p.Type == "Mobile").SingleOrDefault();
            patientDTO.HomePhoneNumber = patient.PhoneNumbers.Where(p => p.Type == "Home").SingleOrDefault();
            patientDTO.WorkPhoneNumber = patient.PhoneNumbers.Where(p => p.Type == "Work").SingleOrDefault();
            patientDTO.IsActive = patient.IsActive;
            patientDTO.Gender = patient.Gender;
            patientDTO.MedicareCardExpiry = patient.MedicareCardExpiry;
            patientDTO.MedicareCardNumber = patient.MedicareCardNumber;
            patientDTO.MedicareCardPosition = patient.MedicareCardPosition;
            patientDTO.SocialHistoryObservation = patient.SocialHistoryObservation;
            patientDTO.VitalSigns = patient.VitalSigns;
            return patientDTO;
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
        [Route("api/patients")]
        public IActionResult Post([FromBody]PatientDetailedDTO patientDTO)
        {
            if (patientDTO.PatientId != 0)
            {
                return new BadRequestResult();
            }
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            var patient = new Patient()
            {
                PatientId = patientDTO.PatientId,
                Title = patientDTO.Title,
                GivenName = patientDTO.GivenName,
                MiddleNames = patientDTO.MiddleNames,
                FamilyName = patientDTO.FamilyName,
                EmailAddress = patientDTO.EmailAddress,
                PhoneNumbers = phoneNumbers,
                IsActive = patientDTO.IsActive,
                DateOfBirth = patientDTO.DateOfBirth,
                Gender = patientDTO.Gender
            };
            DbContext.Add(patient);
            DbContext.SaveChanges();
            return new HttpOkObjectResult(patient);
        }

        [Route("api/patients/{patientId}")]
        [HttpPut]
        public IActionResult Put(int patientId, [FromBody]PatientDetailedDTO patientDTO)
        {
            if (!ModelState.IsValid)
            {
                return this.HttpBadRequest(ModelState);
            }
            if (patientDTO.PatientId == 0)
            {
                return this.HttpNotFound();
            }

            var existingPatient = DbContext.Patients
                .Where(p => p.PatientId == patientDTO.PatientId)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.EmailAddress)
                .Include(p => p.SocialHistoryObservation)
                .Single();
            if (existingPatient != null)
            {
                existingPatient.GivenName = patientDTO.GivenName;
                existingPatient.FamilyName = patientDTO.FamilyName;
                existingPatient.MiddleNames = patientDTO.MiddleNames;
                existingPatient.Title = patientDTO.Title;
                existingPatient.Gender = patientDTO.Gender;
                existingPatient.PreferredName = patientDTO.PreferredName;
                existingPatient.EmailAddress = patientDTO.EmailAddress;
                var existingPhoneNumbers = existingPatient.PhoneNumbers.ToList();
                var newPhoneNumbers = new List<PhoneNumber>();
                if (patientDTO.MobilePhoneNumber != null)
                {
                    newPhoneNumbers.Add(patientDTO.MobilePhoneNumber);
                }
                if (patientDTO.HomePhoneNumber != null)
                {
                    newPhoneNumbers.Add(patientDTO.HomePhoneNumber);
                }
                if (patientDTO.WorkPhoneNumber != null)
                {
                    newPhoneNumbers.Add(patientDTO.WorkPhoneNumber);
                }
                foreach (var existingPhoneNumber in existingPhoneNumbers)
                {
                    // Is the phone number still there?
                    var phoneNumber = newPhoneNumbers.SingleOrDefault(p => p.PhoneNumberId == existingPhoneNumber.PhoneNumberId);

                    if (phoneNumber != null)
                    {
                        // Yes: Update scalar/complex properties of child
                        existingPhoneNumber.Value = phoneNumber.Value;
                        existingPhoneNumber.AreaCode = phoneNumber.AreaCode;
                        existingPhoneNumber.CountryCode = phoneNumber.CountryCode;
                        existingPhoneNumber.IsPreferred = phoneNumber.IsPreferred;
                    }
                    else {
                        // No: Delete it
                        DbContext.PhoneNumbers.Remove(existingPhoneNumber);
                    }
                }
                foreach (var phoneNumber in newPhoneNumbers)
                {
                    // Is the child NOT in DB?
                    if (!existingPhoneNumbers.Any(p => p.PhoneNumberId == phoneNumber.PhoneNumberId))
                    {
                        // Yes: Add it as a new child
                        existingPatient.PhoneNumbers.Add(phoneNumber);
                    }
                }
            }
            DbContext.SaveChanges();
            return this.Ok(patientDTO);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
