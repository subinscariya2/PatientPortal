using Microsoft.AspNetCore.Mvc;
using PatientPortal.Models;
using PatientPortal.Service;

namespace PatientPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatientDatabyId([FromRoute] int id)
        {
            try
            {
                var data = _patientService.GetPatientDatabyId(id);
                if (data == null)
                {
                    return NotFound("No patient data found");
                }
                return Ok(data);
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(401, "Unauthorized access" + ex.Message);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, $"Error occured during process: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error" + ex.Message);
            }
        }
    }
}
