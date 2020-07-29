using api.Models;
using System;
using System.Collections.Generic;

namespace api.Services.Contracts
{
    /// <summary>
    /// Interface: IPatientService
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Function: Returns list of patients.
        /// </summary>
        /// <returns>IEnumerable<Patient></returns>
        IEnumerable<Patient> GetPatientList();

        /// <summary>
        /// Function: Returns list of cities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<City> GetCityList();

        /// <summary>
        /// Function: Returns list of states.
        /// </summary>
        /// <returns></returns>
        IEnumerable<State> GetStateList();

        /// <summary>
        /// Function: Returns list of patients by filter.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Patient> FetchPatients(Patient patient);

        /// <summary>
        /// Function: Add new patient entry to the database.
        /// </summary>
        /// <returns></returns>
        bool AddPatient(Patient patient);

        /// <summary>
        /// Function: Check if the patient already exists.
        /// </summary>
        /// <returns></returns>
        bool CheckPatientExists(Patient patient);

    }
}
