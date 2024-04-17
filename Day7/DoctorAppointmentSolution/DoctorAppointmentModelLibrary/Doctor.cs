﻿namespace DoctorAppointmentModelLibrary
{
    public class Doctor
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Specialization { get; set; }

        public Doctor(string name, string specialization)
        {
            Name = name;
            Specialization = specialization;
        }
    }
}
