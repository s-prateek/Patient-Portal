import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  // API URL
  apiURL = 'https://localhost:5001/api';

  constructor(private httpClient: HttpClient) { }

  // HttpClient API get() method => Get patient list
  public getPatients() {
    return this.httpClient.get<any>(`${this.apiURL}/patient/`);
  }

  // HttpClient API post() method => Add new patient entry
  public savePatient(patientData) {
    return this.httpClient.post<any>(`${this.apiURL}/patient/`, patientData);
  }

  // HttpClient API get() method => Get city list
  public getCities() {
    return this.httpClient.get<any>(`${this.apiURL}/patient/get-cities`);
  }

  // HttpClient API get() method => Get state list
  public getStates() {
    return this.httpClient.get<any>(`${this.apiURL}/patient/get-states`);
  }

  // HttpClient API post() method => Fetch patients by filter data.
  public fetchPatients(patientData) {
    return this.httpClient.post<any>(`${this.apiURL}/patient/fetch`, patientData);
  }
}
