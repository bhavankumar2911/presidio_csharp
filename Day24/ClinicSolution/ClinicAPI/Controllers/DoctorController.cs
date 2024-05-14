using ClinicAPI.Exceptions;
using ClinicAPI.Models;
using ClinicAPI.Services;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController (IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try
            {
                var allDotors = await _doctorService.GetDetailsOfAllDoctors();
                return Ok(allDotors);
            } catch (NoDoctorsAvailableException ndae)
            {
                return NotFound(ndae.Message);
            }
        }

        [HttpGet]
        [Route("speciality")]
        public async Task<ActionResult<IList<Doctor>>> Get(string speciality)
        {
            try
            {
                var doctorsOfASpeciality = await _doctorService.GetAllDoctorsOfASpeciality(speciality);

                return Ok(doctorsOfASpeciality);    
            } catch (NoDoctorsAvailableException ndae)
            {
                return NotFound(ndae.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateExperience (int doctorID, double newExperience)
        {
            try
            {
                var updatedDoctor = await _doctorService.UpdateExperienceOfADoctor(doctorID, newExperience);

                return Ok(updatedDoctor);   
            } catch (DoctorNotFoundException dnfe)
            {
                return NotFound(dnfe.Message);
            }
        }
    }
}
