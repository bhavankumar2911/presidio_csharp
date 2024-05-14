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
    }
}
