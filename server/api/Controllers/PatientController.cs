using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
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

        // GET: api/Patient
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_patientService.GetPatientList());
        }

        // GET: api/Patient/get-cities
        [HttpGet("get-cities")]
        public IActionResult GetCities()
        {
            return Ok(_patientService.GetCityList());
        }

        // GET: api/Patient/get-states
        [HttpGet("get-states")]
        public IActionResult GetStates()
        {
            return Ok(_patientService.GetStateList());
        }

        // POST: api/Patient
        [HttpPost]
        public IActionResult Post([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_patientService.CheckPatientExists(patient))
            {
                return StatusCode(409, $"User '{patient.Name}' already exists.");
            }

            return Ok(_patientService.AddPatient(patient));
        }

        // POST: api/Patient
        [HttpPost("fetch")]
        public IActionResult FetchPatients([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            var patientList = _patientService.FetchPatients(patient);

            return Ok(patientList);
        }


        
    }
}
