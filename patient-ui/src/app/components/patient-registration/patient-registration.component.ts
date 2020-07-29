import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../services/patient.service';
import { ENGINE_METHOD_DIGESTS } from 'constants';

@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.scss']
})
export class PatientRegistrationComponent implements OnInit {
  patientList = [];
  cityList = [];
  cityListToDisplay = [];
  stateList = [];
  genderList = [{name: 'Male', value: 'M'}, {name: 'Female', value: 'F'}];
  patientName = '';
  patientSurName = '';
  selectedCity = null;
  selectedState = null;
  selectedGender = null;
  selectedDOB = '';
  todaysDate = new Date();
  hunderdYearFromToday = new Date(this.todaysDate.getFullYear() + 100, this.todaysDate.getMonth(), this.todaysDate.getDate());
  constructor(private patientService: PatientService) { }

  ngOnInit() {
    const _this = this;
    _this.resetForm();
    _this.getStates();
    _this.getCities();
  }


  fetchPatientByInfo() {
    const _this = this;
    const patientData = {
      Name: _this.patientName,
      SurName: _this.patientSurName,
      DOB: _this.selectedDOB === '' ? new Date() : _this.selectedDOB,
      Gender: _this.selectedGender !== null ? _this.selectedGender['value'] : ''
    };

    _this.patientService.fetchPatients(patientData).subscribe(patientList => {
      if (!patientList || patientList === null) {
        _this.patientList = [];
      }

      _this.patientList = patientList;
    });
  }

  filterCities() {
    this.cityListToDisplay = this.cityList.filter(city => city.stateId === this.selectedState.id);
  }

  savePatient() {
    const _this = this;

    if (_this.selectedDOB === '' ||
      _this.selectedCity === null ||
      _this.selectedState === null ||
      _this.selectedGender === null ||
      _this.patientName === '' ||
      _this.patientSurName === '') {
      alert('All fields are required.');
      return false;
    }

    if (!/^[a-zA-Z]*$/g.test(_this.patientName)) {
      alert('Invalid characters for Patient Name.');
      return false;
    }

    if (!/^[a-zA-Z]*$/g.test(_this.patientSurName)) {
      alert('Invalid characters for Patient Surname.');
      return false;
    }

    const patientData = {
      Name: _this.patientName,
      SurName: _this.patientSurName,
      DOB: _this.selectedDOB,
      Gender: _this.selectedGender !== null ? _this.selectedGender['value'] : '',
      City: _this.selectedCity !== null ? _this.selectedGender['id'] : '',
    };

    _this.patientService.savePatient(patientData).subscribe(result => {
      alert('Successfully Saved!');
      this.resetForm();
    }, error => {
      alert(error.error);
    });

  }

  getCities() {
    const _this = this;
    this.patientService.getCities().subscribe(cities => {
      _this.cityList = cities;
    });
  }

  getStates() {
    const _this = this;
    _this.patientService.getStates().subscribe(states => {
      _this.stateList = states;
    });
  }

  resetForm() {
    this.patientName = '';
    this.patientSurName = '';
    this.selectedCity = null;
    this.selectedState = null;
    this.selectedGender = null;
    this.selectedDOB = '';
  }
}

