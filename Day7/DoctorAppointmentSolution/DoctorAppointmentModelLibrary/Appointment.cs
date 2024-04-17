using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentModelLibrary
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime ConsultingTime { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public bool Status { get; set; }

        public Appointment(DateTime consultingTime, Patient patient, Doctor doctor)
        {
            ConsultingTime = consultingTime;
            Patient = patient;
            Doctor = doctor;
            Status = true;
        }
    }
}
