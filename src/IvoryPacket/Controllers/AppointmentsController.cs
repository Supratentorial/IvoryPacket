using System.Collections.Generic;
using IvoryPacket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IvoryPacket.Controllers
{
    
    public class AppointmentsController : Controller
    {

        private IvoryPacketDbContext dbContext { get; set; }

        public AppointmentsController(IvoryPacketDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("api/appointments")]
        public IEnumerable<Appointment> GetAppointments()
        {
            List<Appointment> appointmentList = new List<Appointment>();
            return appointmentList;
        }

        [Route("api/appointments/{appointmentId}")]
        [HttpGet]
        public string GetAppointmentsById(int appointmentId)
        {
            return "value";
        }

        [Route("api/appointments")]
        [HttpPost]
        public void Post([FromBody]Appointment appointment)
        {
            dbContext.Appointments.Add(appointment);
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
