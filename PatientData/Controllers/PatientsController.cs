using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
    [Authorize]
    public class PatientsController : ApiController
    {

        private readonly IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            return _patients.Find(p => true).ToList();
        }

        public IHttpActionResult Get(string id)
        {
            var patient = _patients.Find(p => p.Id.Equals(id)).FirstOrDefault();
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _patients.Find(p => p.Id.Equals(id)).FirstOrDefault();
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.Medications);
        }
    }
}
