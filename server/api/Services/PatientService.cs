using api.Models;
using api.Services.Contracts;
using AutoMapper;
using iMedOneDB;
using iMedOneDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;

        public PatientService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IEnumerable<Patient> GetPatientList()
        {
            var patients = DBContext.GetData<TBLPATIENT>();
            return _mapper.Map<List<Patient>>(patients);
        }

        public IEnumerable<City> GetCityList()
        {
            var cities = DBContext.GetData<Tblcity>();
            return _mapper.Map<List<City>>(cities);
        }

        public IEnumerable<State> GetStateList()
        {
            var states = DBContext.GetData<Tblstate>();
            return _mapper.Map<List<State>>(states);
        }

        public IEnumerable<Patient> FetchPatients(Patient patient)
        {
            var patients = DBContext.GetData<TBLPATIENT>();

            if (patients == null)
            {
                return new List<Patient>();
            }

            var filteredList = patients.Where(_patient => (_patient.DOB == patient.DOB)
            || (_patient.Name.ToLower() == patient.Name.ToLower().Trim())
            || (_patient.SurName.ToLower() == patient.SurName.ToLower().Trim())
            || (_patient.Gender.ToLower() == patient.Gender.ToLower().Trim()));

            return _mapper.Map<List<Patient>>(filteredList);
        }

        public bool CheckPatientExists(Patient patient)
        {
            var existingPatient = DBContext.GetData<TBLPATIENT>().Where(_patient => (_patient.DOB.Date == patient.DOB.Date)
            && (_patient.Name.ToLower() == patient.Name.ToLower().Trim())
            && (_patient.SurName.ToLower() == patient.SurName.ToLower().Trim())
            && (_patient.Gender.ToLower() == patient.Gender.ToLower().Trim())).FirstOrDefault();

            if (existingPatient != null)
            {
                return true;
            }

            return false;
        }

        public bool AddPatient(Patient patient)
        {
            var patients = new List<TBLPATIENT>();
            patients.Add(_mapper.Map<TBLPATIENT>(patient));
            return DBContext.SaveAll<TBLPATIENT>(patients);
        }
    }
}
