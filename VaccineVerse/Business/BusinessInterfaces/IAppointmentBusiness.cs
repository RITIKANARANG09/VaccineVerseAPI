using System.Collections;
using System.Collections.Generic;
using VaccineVerse.Model;
using VaccineVerse.Model.DTO;

namespace VaccineVerse.Business.BusinessInterfaces
{
    public interface IAppointmentBusiness
    {
        public IEnumerable<Appointment> ViewAppointmentsOfPatient(int? id, string userId);
        public IEnumerable<Appointment> ViewAppointmentsOfAdmin(int? id, string userId);
        public bool AddAppointment(AppointmentViewDTO appointment);
        public bool CancelAppointment(string patientId,int id);
    }
}
