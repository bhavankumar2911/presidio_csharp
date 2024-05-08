using DoctorAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        DoctorAppointmentContext _doctorAppointmentContext;

        public DoctorRepository()
        {
            _doctorAppointmentContext = new DoctorAppointmentContext();
        }

        public Doctor Add(Doctor doctor)
        {
            _doctorAppointmentContext.Doctors.Add(doctor);
            _doctorAppointmentContext.SaveChanges();
            return doctor;
        }

        public Doctor Delete(int doctorID)
        {
            Doctor doctor = _doctorAppointmentContext.Doctors.Find(doctorID);
            _doctorAppointmentContext.Doctors.Remove(doctor);
            _doctorAppointmentContext.SaveChanges();   
            return doctor;
        }

        public Doctor Get(int doctorID)
        {
            return _doctorAppointmentContext.Doctors.Find(doctorID);
        }

        public List<Doctor> GetAll()
        {
            return _doctorAppointmentContext.Doctors.ToList();
        }

        public Doctor Update(Doctor doctor)
        {
            _doctorAppointmentContext.Doctors.Update(doctor);
            _doctorAppointmentContext.SaveChanges();
            return doctor;
        }
    }
}
