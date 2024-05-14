using ClinicAPI.Context;
using ClinicAPI.Exceptions;
using ClinicAPI.Models;
using ClinicAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repository
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContext _context;

        public DoctorRepository (ClinicContext context)
        {
            _context = context;
        }

        async public Task<Doctor> Add(Doctor doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        async public Task<Doctor> Delete(int key)
        {
            var employee = await GetByKey(key);

            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync(true);
                return employee;
            }

            throw new DoctorNotFoundException(key);
        }

        async public Task<IEnumerable<Doctor>> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();

            if (doctors.Count > 0) return doctors;

            throw new NoDoctorsAvailableException();
        }

        public Task<Doctor> GetByKey(int key)
        {
            var doctor = _context.Doctors.FirstOrDefaultAsync(e => e.Id == key);

            if (doctor != null) return doctor;

            throw new DoctorNotFoundException(key);
        }

        async public Task<Doctor> Update(Doctor newDoctor)
        {
            var doctor = await GetByKey(newDoctor.Id);
            
            if (doctor != null)
            {
                _context.Update(newDoctor);
                await _context.SaveChangesAsync(true);
                return newDoctor;
            }

            throw new DoctorNotFoundException(doctor.Id);
        }
    }
}
