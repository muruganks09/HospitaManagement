using Microsoft.AspNetCore.Mvc;
using Patient.Application;
using Patient.Domain.Entities;

namespace Patient.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController : ControllerBase
    {
        readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("{patientId}")]
        public async Task<Patients> GetByPatientId(string patientId) 
        {
            return await _patientService.GetByPatientId(patientId);
        }

        [HttpPost]
        [Route("")]
        public async Task<Patients> Post([FromBody] Patients user)
        {
            return (await _patientService.Insert(user));
        }

        [HttpGet]
        [Route("list")]
        public async Task<IList<Patients>> List(long rowFrom = 0, long rowCount = 10)
        {
            return await _patientService.GetPatientList(rowFrom, rowCount);
        }

        [HttpDelete]
        [Route("{patientId}")]
        public async Task<string> Delete(string patientId)
        {
            await _patientService.Delete(patientId);
            return "Ok";
        }
    }
}
