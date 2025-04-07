using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.ViewModel
{
    public class PatientVM
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public string Operation { get; set; } = "";

        public Patient ToPatient()
        {
            return new Patient()
            {
                PatientID = this.PatientID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                Appointments = this.Appointments


            };
        }

        public PatientVM() { }

        public PatientVM(Patient patient) 
        {
            this.PatientID = patient.PatientID;
            this.FirstName = patient.FirstName;
            this.LastName = patient.LastName;
            this.PhoneNumber = patient.PhoneNumber;
            this.Address = patient.Address;
            this.DateOfBirth = patient.DateOfBirth;
            this.Gender = patient.Gender;
            this.Appointments = patient.Appointments.ToList();

        }




    }

    
}