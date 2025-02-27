using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTBO_LIB2.Models;
using APPOINTMENTDA_LIB2.Repositories;

namespace APPOINTMENTBO_LIB2.BO
{
    public class DoctorBo
    {
        static DoctorRepository docRep = new DoctorRepository();
        public static void UpdateDoctor(string doctorId)
        {
            var doctor = docRep.GetById(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor ID is invalid, Could not find Doctor details.");
            }
            else
            {
                Console.WriteLine("Renter Doctor Name, Specialization, Contact Number and Availabilty Schedule.");
                APPOINTMENTDA_LIB2.Models.Doctor d = new APPOINTMENTDA_LIB2.Models.Doctor()
                {
                    DoctorId = doctor.DoctorId,
                    Name = Console.ReadLine(),
                    Specialization = Console.ReadLine(),
                    ContactNumber = Console.ReadLine(),
                    AvailabailtySchedule = Console.ReadLine()
                };
                bool b = docRep.Update(d);
                if (b)
                {
                    Console.WriteLine("Doctor details updated.");
                }
                else
                {
                    Console.WriteLine("Update operation failure.");
                }
            }
        }

        /*public static void RemoveDoctor(string doctorId)
        {
            var doctor = docRep.GetById(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor ID is invalid, Could not find Doctor details.");
            }
            else
            {
                bool b = docRep.Delete(doctor);
                if (b)
                {
                    Console.WriteLine("Doctor details removed.");
                }
                else
                {
                    Console.WriteLine("Delete operation failure.");
                }
            }
        }*/

        public static void GetDoctorDetails(string doctorId)
        {
            var doctor = docRep.GetById(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor ID is invalid, Could not find Doctor details.");
            }
            else
            {
                Console.WriteLine("{0,10}{1,20}{2,20}{3,15}{4,10}", "DoctorId", "Name", "Specialization", "Contact Number", "Availability Schedule");
                Console.WriteLine(doctor);
            }
        }

        /*public static void ShowDoctors()
        {
            var doctors = docRep.GetAll();
            foreach (var doctor in doctors)
            {
                Console.WriteLine("{0,10}{1,30}{2,10}{3,10}{4,30}{5,10}", "ID", "Appointment Date", "Doctor Id", "Patient Id", "Symptoms", "Consulted Fee");
                Console.WriteLine(doctor);
            }
        }*/

        public static void AddDoctor(Doctor doc)
        {
            APPOINTMENTDA_LIB2.Models.Doctor doctor = new APPOINTMENTDA_LIB2.Models.Doctor();
            doctor.DoctorId = doc.DoctorId;
            doctor.Name = doc.Name;
            doctor.Specialization = doc.Specialization;
            doctor.ContactNumber = doc.ContactNumber;
            doctor.AvailabailtySchedule = doc.AvailabailtySchedule;
            bool b = docRep.Add(doctor);
            if (b)
            {
                Console.WriteLine("Doctor details added.");
            }
            else
            {
                Console.WriteLine("Insert operation failure.");
            }

        }
    }
}
