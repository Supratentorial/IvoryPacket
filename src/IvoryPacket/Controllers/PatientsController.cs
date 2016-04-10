﻿using System.Collections.Generic;
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
        private IvoryPacketDbContext dbContext { get; set; }

        public PatientsController(IvoryPacketDbContext context)
        {
            dbContext = context;
        }

        [Route("api/patients")]
        // GET: api/patients
        [HttpGet]
        public IActionResult Get()
        {
            var patients = dbContext.Patients.Take(40);
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
            patientDTO.SocialHistory = patient.SocialHistory;
            patientDTO.SmokingHistory = patient.SmokingHistory;
            patientDTO.AlcoholHistory = patient.AlcoholHistory;
            patientDTO.DrugHistory = patient.DrugHistory;
            patientDTO.VitalSigns = patient.VitalSigns;
            return patientDTO;
        }

        [HttpGet]
        [Route("api/patients/{patientId}/simple")]
        public PatientSimpleDTO GetSimplePatient(int patientId)
        {
            var patient = dbContext.Patients.Where(p => p.PatientId == patientId).FirstOrDefault();
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
            dbContext.Add(patient);
            dbContext.SaveChanges();
            return new HttpOkObjectResult(patient);
        }

        [Route("api/patients/{patientId}")]
        [HttpPut]
        public IActionResult Put(int patientId, [FromBody]PatientDetailedDTO patientDTO)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            if (patientDTO.PatientId == 0)
            {
                return HttpNotFound();
            }

            var existingPatient = dbContext.Patients
                .Where(p => p.PatientId == patientDTO.PatientId)
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
                existingPatient.GivenName = patientDTO.GivenName;
                existingPatient.FamilyName = patientDTO.FamilyName;
                existingPatient.MiddleNames = patientDTO.MiddleNames;
                existingPatient.Title = patientDTO.Title;
                existingPatient.Gender = patientDTO.Gender;
                existingPatient.PreferredName = patientDTO.PreferredName;
                if (patientDTO.VitalSigns != null)
                {
                    var existingVitalSigns = existingPatient.VitalSigns.ToList();
                    foreach (var existingVitalSign in existingVitalSigns)
                    {
                        var vitalSign = patientDTO.VitalSigns.SingleOrDefault(v => v.VitalSignId == existingVitalSign.VitalSignId);
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
                        else {
                            dbContext.VitalSigns.Remove(existingVitalSign);
                        }
                    }
                    foreach (var vitalSign in patientDTO.VitalSigns)
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
                    if (patientDTO.EmailAddress != null)
                    {
                        existingPatient.EmailAddress.EmailValue = patientDTO.EmailAddress.EmailValue;
                    }
                    else if (patientDTO.EmailAddress == null)
                    {
                        dbContext.EmailAddresses.Remove(existingPatient.EmailAddress);
                    }
                }
                else {
                    existingPatient.EmailAddress = patientDTO.EmailAddress;
                }

                if (existingPatient.SmokingHistory != null)
                {
                    if (patientDTO.SmokingHistory != null)
                    {
                        existingPatient.SmokingHistory.SmokingStatus = patientDTO.SmokingHistory.SmokingStatus;
                        existingPatient.SmokingHistory.CigarettesPerDay = patientDTO.SmokingHistory.CigarettesPerDay;
                        existingPatient.SmokingHistory.AgeSmokingCommenced = patientDTO.SmokingHistory.AgeSmokingCommenced;
                        existingPatient.SmokingHistory.AgeSmokingCeased = patientDTO.SmokingHistory.AgeSmokingCeased;
                        existingPatient.SmokingHistory.Notes = patientDTO.SmokingHistory.Notes;
                    }
                    else if (patientDTO.SmokingHistory == null)
                    {

                    }
                }
                else if (patientDTO.SmokingHistory != null)
                {
                    existingPatient.SmokingHistory = patientDTO.SmokingHistory;
                }

                if (existingPatient.SocialHistory != null)
                {
                    if (patientDTO.SocialHistory != null)
                    {
                        existingPatient.SocialHistory.Ethnicity = patientDTO.SocialHistory.Ethnicity;
                        existingPatient.SocialHistory.MaritalStatus = patientDTO.SocialHistory.MaritalStatus;
                        existingPatient.SocialHistory.Occupation = patientDTO.SocialHistory.Occupation;
                        existingPatient.SocialHistory.Religion = patientDTO.SocialHistory.Religion;
                    }
                }
                else if (patientDTO.SmokingHistory != null) {
                    existingPatient.SocialHistory = patientDTO.SocialHistory;
                }
            }
            dbContext.SaveChanges();
            return this.Ok(patientDTO);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
