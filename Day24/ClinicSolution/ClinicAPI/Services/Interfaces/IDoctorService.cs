using ClinicAPI.Models;

namespace ClinicAPI.Services.Interfaces
{
    public interface IDoctorService
    {
        public Task<IList<Doctor>> GetDetailsOfAllDoctors();

        public Task<Doctor> UpdateExperienceOfADoctor(int doctorId, double newExperience);

        public Task<IList<Doctor>> GetAllDoctorsOfASpeciality(string speciality);
    }
}
