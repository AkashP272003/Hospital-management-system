using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTBO_LIB2.Models;
using APPOINTMENTDA_LIB2.Repositories;

namespace APPOINTMENTBO_LIB2.BO
{
    public class PatientBO
    {
        static PatientRepository patRep = new PatientRepository();
        public static void UpdatePatient(int patId)
        {
            var patient = patRep.GetById(patId);
            if (patient == null)
            {
                Console.WriteLine("Patient ID is invalid, Could not find patient details.");
            }
            else
            {
                Console.WriteLine("Renter Patient Name, DOB(MM/dd/yyy), Gender, Contact Number, Address, Medical History");
                APPOINTMENTDA_LIB2.Models.Patient p = new APPOINTMENTDA_LIB2.Models.Patient()
                {
                    PatientId = patient.PatientId,
                    Name = Console.ReadLine(),
                    DateOfBirth = DateTime.Parse(Console.ReadLine()),
                    Gender = Console.ReadLine(),
                    ContactNumber = Console.ReadLine(),
                    Address = Console.ReadLine(),
                    MedicalHistory = Console.ReadLine()
                };
                bool b = patRep.Update(p);
                if (b)
                {
                    Console.WriteLine("Patient details updated.");
                }
                else
                {
                    Console.WriteLine("Update operation failure.");
                }
            }
        }

        public static void DeletePatient(int patientId)
        {
            var patient = patRep.GetById(patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient ID is invalid, Could not find Patient details.");
            }
            else
            {
                bool b = patRep.Delete(patient);
                if (b)
                {
                    Console.WriteLine("Patient details removed.");
                }
                else
                {
                    Console.WriteLine("Delete operation failure.");
                }
            }
        }

        public static void GetPatientDetails(int patientId)
        {
            var patient = patRep.GetById(patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient ID is invalid, Could not find patient details.");
            }
            else
            {
                Console.WriteLine("{0,10}{1,20}{2,15}{3,5}{4,15}{5,30}{6,25}", "Patient Id", "Name", "Date Of Birth", "Gender", "Contact Number", "Address", "Medical History");
                Console.WriteLine(patient);
            }
        }

        public static void AddPatient(Patient pat)
        {
            APPOINTMENTDA_LIB2.Models.Patient patient = new APPOINTMENTDA_LIB2.Models.Patient();
            patient.PatientId = pat.PatientId;
            patient.Name = pat.Name;
            patient.DateOfBirth = pat.DateOfBirth;
            patient.Gender = pat.Gender;
            patient.ContactNumber = pat.ContactNumber;
            patient.Address = pat.Address;
            patient.MedicalHistory = pat.MedicalHistory;
            bool b = patRep.Add(patient);
            if (b)
            {
                Console.WriteLine("Patient details added.");
            }
            else
            {
                Console.WriteLine("Insert operation failure.");
            }

        }
    }
}
