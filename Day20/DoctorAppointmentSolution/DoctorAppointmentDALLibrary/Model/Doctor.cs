using System;
using System.Collections.Generic;

namespace DoctorAppointmentDALLibrary.Model
{
    public partial class Doctor
    {
        public int DoctoId { get; set; }
        public string? DoctorName { get; set; }
        public string? Specialization { get; set; }
    }
}
