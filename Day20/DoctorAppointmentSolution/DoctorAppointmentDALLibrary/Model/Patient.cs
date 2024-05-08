using System;
using System.Collections.Generic;

namespace DoctorAppointmentDALLibrary.Model
{
    public partial class Patient
    {
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? Age { get; set; }
        public string? Phone { get; set; }
    }
}
