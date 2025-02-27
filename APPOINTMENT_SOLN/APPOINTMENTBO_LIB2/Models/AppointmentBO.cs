using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using APPOINTMENTDA_LIB2.Models;
using APPOINTMENTDA_LIB2.Repositories;

namespace APPOINTMENTBO_LIB2.Models
{
    public class AppointmentBO
    {
        
        static AppointmentRepository appoRep = new AppointmentRepository();
        

        


        public static void getAppointmentDetails(int appointmentId)
        {
            var appointment = appoRep.GetById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("ID is invalid, Could not find appointment details.");
            }
            else
            {
                Console.WriteLine("Renter ID");
                APPOINTMENTDA_LIB2.Models.Appointment a = new APPOINTMENTDA_LIB2.Models.Appointment()
                {
                    AppointmentId = appointment.AppointmentId,
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    AppointmentDate = appointment.AppointmentDate,
                    TimeSlot = appointment.TimeSlot,
                    Status = appointment.Status
                };
                bool b = appoRep.Update(a);
                if (b)
                {
                    Console.WriteLine("Appointment details updated.");
                }
                else
                {
                    Console.WriteLine("Update operation failure.");
                }
            }
        }

        
        

        public static void CancelAppointment(int Id)
        {
            var appointment = appoRep.GetById(Id);
            if (appointment == null)
            {
                Console.WriteLine("ID is invalid, Could not find Appointment details.");
            }
            else
            {
                bool b = appoRep.Delete(appointment);
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

        
        

        
        public static void GetAppointmentDetails(int appointmentId)
        {
            var appointment = appoRep.GetById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("ID is invalid, Could not find Appointment details.");
            }
            else
            {//{AppointmentId,10}{PatientId,10}{DoctorId,10}{AppointmentDate,20}{TimeSlot,10}{Status,10}");
                Console.WriteLine("{0,20}{1,15}{2,10}{3,25}{4,10}{5,10}", "Appointment ID", "Patient Id", "Doctor Id", "Appointment Date", "Time Slot", "Status");
                Console.WriteLine(appointment);
            }
        }

        

        /*public static void ShowPatients()
        {
            var patients = patRep.GetAll();
            Console.WriteLine("{0,10}{1,30}{2,15}", "PatientId", "PatientName", "Mobile No");
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }
        }*/

        public static void ShowAppointments()
        {
            var appointments = appoRep.GetAll();
            Console.WriteLine("{0,10}{1,30}{2,10}{3,10}{4,30}{5,10}", "ID", "Appointment Date", "Doctor Id", "Patient Id", "Symptoms", "Consulted Fee");
            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment);
            }
        }

        
        

        public static void ScheduleAppointment(Appointment app)
        {
            APPOINTMENTDA_LIB2.Models.Appointment appointment = new APPOINTMENTDA_LIB2.Models.Appointment();
            appointment.AppointmentId = app.AppointmentId;
            appointment.PatientId = app.PatientId;
            appointment.DoctorId = app.DoctorId;
            appointment.AppointmentDate = app.AppointmentDate;
            appointment.TimeSlot = app.TimeSlot;
            appointment.Status = app.Status;
            bool b = appoRep.Add(appointment);
            if (b)
            {
                Console.WriteLine("Appointment details added.");
            }
            else
            {
                Console.WriteLine("Insert operation failure.");
            }
        }

        

        

    }
}
