using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;
using VaccineVerse.Model.DTO;

namespace VaccineVerse.Business
{
    public class AppointmentBusiness:IAppointmentBusiness
    {
        public ApiDbContext Context { get; set; }
        public AppointmentBusiness(ApiDbContext context)
        {
            this.Context = context;
        }
        public IEnumerable<Appointment> ViewAppointmentsOfPatient(int? id, string userId)
        {


            if (id.HasValue)
            {
                var appointment = Context.Appointments.Where(a => a.AppointmentId == id && a.PatientId == userId);
                return appointment;
            }
            var appointments = Context.Appointments.Where(a => a.PatientId == userId);
            return appointments;
        }
        public IEnumerable<Appointment> ViewAppointmentsOfAdmin(int? id, string userId)
        {

            int centerId = Convert.ToInt32(userId);
            if (id.HasValue)
            {
                var appointment = Context.Appointments.Where(a => a.AppointmentId == id && a.VaccinationCenterId == centerId);
                return appointment;
            }
            var appointments = Context.Appointments.Where(a => a.VaccinationCenterId == centerId);
            return appointments;
        }
        public bool AddAppointment(AppointmentViewDTO appointment)
        {
            Appointment appointmentObj = new Appointment()
            {
                VaccineId = appointment.VaccineId,
                VaccinationCenterId = appointment.VaccinationCenterId,
                Date = DateTime.ParseExact(appointment.DateTime, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                PatientId = appointment.PatientId
            };
        
          
            Context.Appointments.Add(appointmentObj);
            Context.SaveChanges();
            return true;
        }
        public bool CancelAppointment(string patientId,int id)
        {
            var appointmentsList=Context.Appointments.Where(a=>a.PatientId==patientId);
            var appointment = appointmentsList.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment == null) return false;
            
            Context.Appointments.Remove(appointment);
            Context.SaveChanges();
            return true;
        }
    }
}
