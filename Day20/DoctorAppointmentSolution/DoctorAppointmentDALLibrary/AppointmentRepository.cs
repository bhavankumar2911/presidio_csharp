using DoctorAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        DoctorAppointmentContext _doctorAppointmentContext;

        public AppointmentRepository()
        {
            _doctorAppointmentContext = new DoctorAppointmentContext();
        }

        public Appointment Add(Appointment appointment)
        {
            _doctorAppointmentContext.Appointments.Add(appointment);
            _doctorAppointmentContext.SaveChanges();
            return appointment;
        }

        public Appointment Delete(int appointmentID)
        {
            Appointment appointment = _doctorAppointmentContext.Appointments.Find(appointmentID);
            _doctorAppointmentContext.Appointments.Remove(appointment);
            _doctorAppointmentContext.SaveChanges();
            return appointment;
        }

        public Appointment Get(int appointmentID)
        {
            return _doctorAppointmentContext.Appointments.Find(appointmentID);
        }

        public List<Appointment> GetAll()
        {
            return _doctorAppointmentContext.Appointments.ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            _doctorAppointmentContext.Appointments.Update(appointment);
            _doctorAppointmentContext.SaveChanges();
            return appointment;
        }
    }
}
