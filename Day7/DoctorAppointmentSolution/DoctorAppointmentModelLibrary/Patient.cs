using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentModelLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Age { get; set; }

        public Patient(string name, float age)
        {
            Name = name;
            Age = age;
        }
    }
}
