using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;
using VaccineVerse.Model.DTO;

namespace VaccineVerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AppointmentController : Controller
    {
        private readonly IAppointmentBusiness appointment;

        public AppointmentController(IAppointmentBusiness appointment)
        {
            this.appointment = appointment;
        }
        [HttpGet]
        [Authorize(Roles = "Patient,Admin")]
        public IActionResult Get(int? id)
        {
            try
            {
                IEnumerable<Appointment> result = null;
                if (User.IsInRole("Admin"))
                {
                    var userId = User.Identity.GetUserId();
                    result = appointment.ViewAppointmentsOfAdmin(id, userId);
                }
                else if (User.IsInRole("Patient"))
                {

                    var userId = User.Identity.GetUserId();
                    result = appointment.ViewAppointmentsOfPatient(id, userId);
                }

                if (result == null)
                    return NotFound("No appointments");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
           
        }
        [HttpPost]
        [Authorize(Roles = "Patient")]
        public IActionResult Post([FromBody] AppointmentViewDTO appointmentObj)
        {
            try
            {
                var patientId = User.Identity.GetUserId();
                appointmentObj.PatientId = patientId;
                var result = appointment.AddAppointment(appointmentObj);
                if (result == false)
                    return BadRequest("Appointment already exists");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
            
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Patient")]
        public IActionResult Delete(int id)
        {
            try
            {
                var patientId = User.Identity.GetUserId();
                var result = appointment.CancelAppointment(patientId, id);
                if (result == false)
                    return BadRequest("You don't have any appointments yet.");
                return Ok("Appointment deleted successfully");
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
          
        }
    }
}
