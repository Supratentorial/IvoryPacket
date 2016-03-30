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

            var mobilePhone = patient.PhoneNumbers.Where(p => p.Type == "Mobile").SingleOrDefault();
            var homePhone = patient.PhoneNumbers.Where(p => p.Type == "Home").SingleOrDefault();
            var workPhone = patient.PhoneNumbers.Where(p => p.Type == "Work").SingleOrDefault();
            if (mobilePhone != null)
            {
                patientDTO.MobilePhoneId = mobilePhone.PhoneNumberId;
                patientDTO.MobilePhoneCountryCode = mobilePhone.CountryCode;
                patientDTO.MobilePhoneNumber = mobilePhone.Value;
            }
            if (homePhone != null)
            {
                patientDTO.HomePhoneId = homePhone.PhoneNumberId;
                patientDTO.HomePhoneCountryCode = homePhone.CountryCode;
                patientDTO.HomePhoneAreaCode = homePhone.AreaCode;
                patientDTO.HomePhoneNumber = homePhone.Value;
            }
            if (workPhone != null)
            {
                patientDTO.WorkPhoneId = workPhone.PhoneNumberId;
                patientDTO.WorkPhoneCountryCode = workPhone.CountryCode;
                patientDTO.WorkPhoneAreaCode = workPhone.AreaCode;
                patientDTO.WorkPhoneNumber = workPhone.Value;
            }
            patientDTO.IsActive = patient.IsActive;
            patientDTO.Gender = patient.Gender;
            patientDTO.MedicareCardExpiry = patient.MedicareCardExpiry;
            patientDTO.MedicareCardNumber = patient.MedicareCardNumber;
            patientDTO.MedicareCardPosition = patient.MedicareCardPosition;
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
        [Route("api/patients/{patientId}/detailed")]
        public IActionResult Post([FromBody]PatientDetailedDTO patientDTO)
        {
            var mobilePhone = new PhoneNumber()
            {
                PhoneNumberId = patientDTO.MobilePhoneId,
                CountryCode = patientDTO.MobilePhoneCountryCode,
                Value = patientDTO.MobilePhoneNumber,
                Type = "Mobile"
            };
            var homePhone = new PhoneNumber()
            {
                PhoneNumberId = patientDTO.HomePhoneId,
                CountryCode = patientDTO.HomePhoneCountryCode,
                AreaCode = patientDTO.HomePhoneAreaCode,
                Type = "Home",
                Value = patientDTO.HomePhoneNumber
            };
            var workPhone = new PhoneNumber()
            {
                PhoneNumberId = patientDTO.WorkPhoneId,
                CountryCode = patientDTO.WorkPhoneCountryCode,
                AreaCode = patientDTO.WorkPhoneAreaCode,
                Type = "Work",
                Value = patientDTO.WorkPhoneNumber
            };

            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();

            phoneNumbers.Add(mobilePhone);
            phoneNumbers.Add(homePhone);
            phoneNumbers.Add(workPhone);
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
            if (patientDTO.PatientId == 0)
            {
                return new BadRequestResult();
            }

            var existingPatient = DbContext.Patients
                .Where(p => p.PatientId == patientDTO.PatientId)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.EmailAddress)
                .Single();
            if (existingPatient != null)
            {
                existingPatient.GivenName = patientDTO.GivenName;
                existingPatient.FamilyName = patientDTO.FamilyName;
                existingPatient.MiddleNames = patientDTO.MiddleNames;
                existingPatient.Title = patientDTO.Title;
                existingPatient.Gender = patientDTO.Gender;
                existingPatient.PreferredName = patientDTO.PreferredName;

                var existingMobile = existingPatient.PhoneNumbers.Where(p => p.PhoneNumberId == patientDTO.MobilePhoneId).SingleOrDefault();
                if (existingMobile != null)
                {
                    if (patientDTO.MobilePhoneCountryCode != 0 && !string.IsNullOrEmpty(patientDTO.MobilePhoneNumber))
                    {
                        existingMobile.CountryCode = patientDTO.MobilePhoneCountryCode;
                        existingMobile.Value = patientDTO.MobilePhoneNumber;
                    }
                    else {
                        DbContext.PhoneNumbers.Remove(existingMobile);
                    }
                }
                else {
                    var newMobilePhone = new PhoneNumber()
                    {
                        PhoneNumberId = patientDTO.MobilePhoneId,
                        CountryCode = patientDTO.MobilePhoneCountryCode,
                        Type = "Mobile",
                        Value = patientDTO.MobilePhoneNumber
                    };
                    existingPatient.PhoneNumbers.Add(newMobilePhone);
                }


                //    var homePhone = new PhoneNumber()
                //    {
                //        PhoneNumberId = patientDTO.HomePhoneId,
                //        CountryCode = patientDTO.HomePhoneCountryCode,
                //        AreaCode = patientDTO.HomePhoneAreaCode,
                //        Type = "Home",
                //        Value = patientDTO.HomePhoneNumber
                //    };

                //var workPhone = new PhoneNumber()
                //{
                //    PhoneNumberId = patientDTO.WorkPhoneId,
                //    CountryCode = patientDTO.WorkPhoneCountryCode,
                //    AreaCode = patientDTO.WorkPhoneAreaCode,
                //    Type = "Work",
                //    Value = patientDTO.WorkPhoneNumber
                //};

                //existingPatient.PhoneNumbers.Add(workPhone);
                //existingPatient.PhoneNumbers.Add(homePhone);


                if (patientDTO.EmailAddress != null && !string.IsNullOrEmpty(patientDTO.EmailAddress.EmailValue))
                {
                    if (existingPatient.EmailAddress != null)
                    {
                        existingPatient.EmailAddress.EmailValue = patientDTO.EmailAddress.EmailValue;
                        existingPatient.EmailAddress.IsPreferred = patientDTO.EmailAddress.IsPreferred;
                    }
                }
                else {
                    existingPatient.EmailAddress = new EmailAddress()
                    {
                        EmailValue = patientDTO.EmailAddress.EmailValue,
                        IsPreferred = patientDTO.EmailAddress.IsPreferred
                    };
                }


            }

            DbContext.SaveChanges();
            return new HttpOkObjectResult(patientDTO);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
