namespace ClinicAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public double Experience { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nSpeciality: {Speciality}\nExperience: {Experience}";
        }
    }
}
