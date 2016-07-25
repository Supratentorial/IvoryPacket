using System.Collections.Generic;
using System.Linq;
using IvoryPacket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IvoryPacket.Controllers
{

    public class PatientsController : Controller
    {
        private IvoryPacketDbContext dbContext;

        public PatientsController(IvoryPacketDbContext context)
        {
            dbContext = context;
        }

        [Route("api/patients")]
        // GET: api/patients
        [HttpGet]
        public IActionResult GetPatients(string searchString = "", bool isActive = true, bool hasAppointmentToday = false, bool detailed = false)
        {
            var patients = dbContext.Patients.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                string[] searchStrings = searchString.Split(' ');
                foreach (string term in searchStrings)
                {
                    patients = patients.Where(p => p.GivenName.Contains(term) || p.FamilyName.Contains(term) || p.PreferredName.Contains(term));
                }
                
            }
  

            //patients = patients.Where(p => p.IsActive == isActive);
            if (hasAppointmentToday)
            {
                //TODO: Change to check for appointments today
                patients = patients.Where(p => p.Appointments.Any());
            }
            if (detailed)
            {
                patients = patients
                .Include(p => p.EmailAddress)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.SocialHistory)
                .Include(p => p.SmokingHistory)
                .Include(p => p.AlcoholHistory)
                .Include(p => p.DrugHistory)
                .Include(p => p.VitalSigns);
            }
            return Ok(patients.ToList());
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/patients/{patientId}")]
        public Patient GetPatientById(int patientId, bool detailed = false)
        {
            var patient = dbContext.Patients
                .Where(p => p.PatientId == patientId)
                .Include(p => p.EmailAddress)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.SocialHistory)
                .Include(p => p.SmokingHistory)
                .Include(p => p.AlcoholHistory)
                .Include(p => p.DrugHistory)
                .Include(p => p.VitalSigns)
                .SingleOrDefault();
            return patient;
        }

        [HttpPost]
        [Route("api/patients")]
        public IActionResult Post([FromBody]Patient patient)
        {
            if (patient.PatientId != 0)
            {
                return BadRequest();
            }
            dbContext.Add(patient);
            dbContext.SaveChanges();
            return Ok(patient);
        }

        [Route("api/patients/{patientId}")]
        [HttpPut]
        public IActionResult Put(int patientId, [FromBody]Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (patient.PatientId == 0)
            {
                return NotFound();
            }

            var existingPatient = dbContext.Patients
                .Where(p => p.PatientId == patient.PatientId)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.EmailAddress)
                .Include(p => p.SocialHistory)
                .Include(p => p.SmokingHistory)
                .Include(p => p.AlcoholHistory)
                .Include(p => p.DrugHistory)
                .Include(p => p.VitalSigns)
                .Single();
            if (existingPatient != null)
            {
                existingPatient.GivenName = patient.GivenName;
                existingPatient.FamilyName = patient.FamilyName;
                existingPatient.MiddleNames = patient.MiddleNames;
                existingPatient.Title = patient.Title;
                existingPatient.Gender = patient.Gender;
                existingPatient.PreferredName = patient.PreferredName;
                if (patient.VitalSigns != null)
                {
                    var existingVitalSigns = existingPatient.VitalSigns.ToList();
                    foreach (var existingVitalSign in existingVitalSigns)
                    {
                        var vitalSign = patient.VitalSigns.SingleOrDefault(v => v.VitalSignId == existingVitalSign.VitalSignId);
                        if (vitalSign != null)
                        {
                            existingVitalSign.HeartRate = vitalSign.HeartRate;
                            existingVitalSign.OxygenSaturation = vitalSign.OxygenSaturation;
                            existingVitalSign.RespiratoryRate = vitalSign.RespiratoryRate;
                            existingVitalSign.SystolicBloodPressure = vitalSign.SystolicBloodPressure;
                            existingVitalSign.DiastolicBloodPressure = vitalSign.DiastolicBloodPressure;
                            existingVitalSign.Temperature = vitalSign.Temperature;
                            existingVitalSign.Height = vitalSign.Height;
                            existingVitalSign.Weight = vitalSign.Weight;
                        }
                        else
                        {
                            dbContext.VitalSigns.Remove(existingVitalSign);
                        }
                    }
                    foreach (var vitalSign in patient.VitalSigns)
                    {
                        // Is the child NOT in DB?
                        if (!existingVitalSigns.Any(v => v.VitalSignId == vitalSign.VitalSignId))
                        {
                            // Yes: Add it as a new child
                            existingPatient.VitalSigns.Add(vitalSign);
                        }
                    }
                }
                var existingPhoneNumbers = existingPatient.PhoneNumbers.ToList();
                var newPhoneNumbers = new List<PhoneNumber>();

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
                    else
                    {
                        // No: Delete it
                        dbContext.PhoneNumbers.Remove(existingPhoneNumber);
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
                if (existingPatient.EmailAddress != null)
                {
                    if (patient.EmailAddress != null)
                    {
                        existingPatient.EmailAddress.EmailValue = patient.EmailAddress.EmailValue;
                    }
                    else if (patient.EmailAddress == null)
                    {
                        dbContext.EmailAddresses.Remove(existingPatient.EmailAddress);
                    }
                }
                else
                {
                    existingPatient.EmailAddress = patient.EmailAddress;
                }

                if (existingPatient.SmokingHistory != null)
                {
                    if (patient.SmokingHistory != null)
                    {
                        existingPatient.SmokingHistory.SmokingStatus = patient.SmokingHistory.SmokingStatus;
                        existingPatient.SmokingHistory.CigarettesPerDay = patient.SmokingHistory.CigarettesPerDay;
                        existingPatient.SmokingHistory.AgeSmokingCommenced = patient.SmokingHistory.AgeSmokingCommenced;
                        existingPatient.SmokingHistory.AgeSmokingCeased = patient.SmokingHistory.AgeSmokingCeased;
                        existingPatient.SmokingHistory.Notes = patient.SmokingHistory.Notes;
                    }
                    else if (patient.SmokingHistory == null)
                    {

                    }
                }
                else if (patient.SmokingHistory != null)
                {
                    existingPatient.SmokingHistory = patient.SmokingHistory;
                }

                if (existingPatient.SocialHistory != null)
                {
                    if (patient.SocialHistory != null)
                    {
                        existingPatient.SocialHistory.Ethnicity = patient.SocialHistory.Ethnicity;
                        existingPatient.SocialHistory.MaritalStatus = patient.SocialHistory.MaritalStatus;
                        existingPatient.SocialHistory.Occupation = patient.SocialHistory.Occupation;
                        existingPatient.SocialHistory.Religion = patient.SocialHistory.Religion;
                    }
                }
                else if (patient.SmokingHistory != null)
                {
                    existingPatient.SocialHistory = patient.SocialHistory;
                }
            }
            dbContext.SaveChanges();
            return Ok(patient);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
