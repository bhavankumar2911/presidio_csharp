using ClinicAPI.Models;
using ClinicAPI.Repository.Interfaces;
using ClinicAPI.Services.Interfaces;

namespace ClinicAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }

        async public Task<IList<Doctor>> GetAllDoctorsOfASpeciality(string speciality)
        {
            var allDoctors = await _repository.GetAll();
            IList<Doctor> doctorsOfASpeciality = new List<Doctor>();    

            foreach (var doctor in allDoctors)
            {
                if (doctor.Speciality.ToLower() == speciality.ToLower()) doctorsOfASpeciality.Add(doctor);
            }

            return doctorsOfASpeciality;
        }

        async public Task<IList<Doctor>> GetDetailsOfAllDoctors()
        {
            var allDoctors = await _repository.GetAll();
            return allDoctors.ToList();
        }

        async public Task<Doctor> UpdateExperienceOfADoctor(int doctorId, double newExperience)
        {
            Doctor doctor = await _repository.GetByKey(doctorId);
            doctor.Experience = newExperience;
            await _repository.Update(doctor);
            return doctor;
        }
    }
}
