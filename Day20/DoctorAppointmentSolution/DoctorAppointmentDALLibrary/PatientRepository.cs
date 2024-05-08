using DoctorAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        DoctorAppointmentContext _doctorAppointmentContext;

        public PatientRepository()
        {
            _doctorAppointmentContext = new DoctorAppointmentContext();
        }

        public Patient Add(Patient patient)
        {
            _doctorAppointmentContext.Patients.Add(patient);
            _doctorAppointmentContext.SaveChanges();
            return patient;
        }

        public Patient Delete(int patientID)
        {
            Patient patient = _doctorAppointmentContext.Patients.Find(patientID);
            _doctorAppointmentContext.Patients.Remove(patient);
            _doctorAppointmentContext.SaveChanges();
            return patient;
        }

        public Patient Get(int patientID)
        {
            return _doctorAppointmentContext.Patients.Find(patientID);
        }

        public List<Patient> GetAll()
        {
            return _doctorAppointmentContext.Patients.ToList();
        }

        public Patient Update(Patient patient)
        {
            _doctorAppointmentContext.Patients.Update(patient);
            _doctorAppointmentContext.SaveChanges();
            return patient;
        }
    }
}
