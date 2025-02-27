using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APPOINTMENTBO_LIB2.BO;
using APPOINTMENTBO_LIB2.Models;

namespace ConsoleApp1
{
    public class Test
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Choose a Controller:");
                Console.WriteLine("1. Doctor");
                Console.WriteLine("2. Patient");
                Console.WriteLine("3. Appointment");
                Console.WriteLine("4. Bill");
                Console.WriteLine("5. User");
                Console.WriteLine("6. Exit");

                int controllerChoice = Int32.Parse(Console.ReadLine());

                switch (controllerChoice)
                {
                    case 1: // Doctor Controller
                        HandleDoctorOperations();
                        break;
                    case 2: // Patient Controller
                        HandlePatientOperations();
                        break;
                    case 3: // Appointment Controller
                        HandleAppointmentOperations();
                        break;
                    case 4: // Bill Controller
                        HandleBillOperations();
                        break;
                    case 5: // User Controller
                        HandleUserOperations();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.Read();
        }


        static void HandleDoctorOperations()
        {
            while (true)
            {
                Console.WriteLine("\nDoctor Operations:");
                Console.WriteLine("1. Add Doctor Details");
                Console.WriteLine("2. Update Doctor Details");
                Console.WriteLine("3. Search Doctor Details");
                Console.WriteLine("4. Back to Main Menu");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Want to add Doctor details? Press y to continue.");
                        string ans = Console.ReadLine();
                        while (ans.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter Doctor Id, Name, Specialization, Contact Number and Availability Schedule.");
                            Doctor d = new Doctor()
                            {
                                DoctorId = 0,
                                Name = Console.ReadLine(),
                                Specialization = Console.ReadLine(),
                                ContactNumber = Console.ReadLine(),
                                AvailabailtySchedule = Console.ReadLine()
                            };
                            DoctorBo.AddDoctor(d);
                            Console.WriteLine("Want to add more Doctor details? Press y to continue.");
                            ans = Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Updating a particular Doctor.");
                        Console.WriteLine("Enter Doctor ID.");
                        string docId3 = Console.ReadLine();
                        DoctorBo.UpdateDoctor(docId3);
                        break;
                    case 3:
                        Console.WriteLine("Searching a particular Doctor.");
                        Console.WriteLine("Enter Doctor ID.");
                        string docId = Console.ReadLine();
                        DoctorBo.GetDoctorDetails(docId);
                        break;
                    case 4:
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ... (Similar HandlePatientOperations, HandleAppointmentOperations, HandleBillOperations, HandleUserOperations methods below)

        static void HandlePatientOperations()
        {
            while (true)
            {
                Console.WriteLine("\nPatient Operations:");
                Console.WriteLine("1. Add Patient Details");
                Console.WriteLine("2. Modify Patient Details");
                Console.WriteLine("3. Search Patient Details");
                Console.WriteLine("4. Delete Patient Details");
                Console.WriteLine("5. Back to Main Menu");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Want to add Patient details? Press y to continue.");
                        string ans = Console.ReadLine();
                        while (ans.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter Patient Name, DOB(MM/dd/yyyy), Gender, Contact Number, Address and Medical History");
                            Patient p = new Patient()
                            {
                                PatientId = 0,
                                Name = Console.ReadLine(),
                                DateOfBirth = DateTime.Parse(Console.ReadLine()),
                                Gender = Console.ReadLine(),
                                ContactNumber = Console.ReadLine(),
                                Address = Console.ReadLine(),
                                MedicalHistory = Console.ReadLine()
                            };
                            PatientBO.AddPatient(p);
                            Console.WriteLine("Want to add more Patient details? Press y to continue.");
                            ans = Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Updating a particular Patient.");
                        Console.WriteLine("Enter Patient ID.");
                        int patId3 = Int32.Parse(Console.ReadLine());
                        PatientBO.UpdatePatient(patId3);
                        break;
                    case 3:
                        Console.WriteLine("Searching a particular Patient.");
                        Console.WriteLine("Enter Patient ID.");
                        int patId = Int32.Parse(Console.ReadLine());
                        PatientBO.GetPatientDetails(patId);
                        break;
                    case 4:
                        Console.WriteLine("Deleting a particular Patient.");
                        Console.WriteLine("Enter Patient ID.");
                        int patId2 = Int32.Parse(Console.ReadLine());
                        PatientBO.DeletePatient(patId2);
                        break;
                    case 5:
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void HandleAppointmentOperations()
        {
            while (true)
            {
                Console.WriteLine("\nAppointment Operations:");
                Console.WriteLine("1. Make Appointment");
                Console.WriteLine("2. Search Appointment");
                Console.WriteLine("3. Delete Appointment");
                Console.WriteLine("4. Back to Main Menu");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Want to make an appointment? Press y to continue.");
                        string ans = Console.ReadLine();
                        while (ans.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter PatientId, DoctorId, AppointmentDate, TimeSlot, Status.");
                            Appointment a = new Appointment()
                            {
                                AppointmentId = 0,
                                PatientId = Int32.Parse(Console.ReadLine()),
                                DoctorId = Int32.Parse(Console.ReadLine()),
                                AppointmentDate = DateTime.Parse(Console.ReadLine()),
                                TimeSlot = Console.ReadLine(),
                                Status = Console.ReadLine()
                            };
                            AppointmentBO.ScheduleAppointment(a);
                            Console.WriteLine("Want to make another Appointment? Press y to continue.");
                            ans = Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Searching an appointment");
                        Console.WriteLine("Enter ID.");
                        int appoId = Int32.Parse(Console.ReadLine());
                        AppointmentBO.GetAppointmentDetails(appoId);
                        break;
                    case 3:
                        Console.WriteLine("Deleting an appointment.");
                        Console.WriteLine("Enter ID.");
                        int appoId2 = Int32.Parse(Console.ReadLine());
                        AppointmentBO.CancelAppointment(appoId2);
                        break;
                    case 4:
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void HandleBillOperations()
        {
            while (true)
            {
                Console.WriteLine("\nBill Operations:");
                Console.WriteLine("1. Add Bill Details ");
                Console.WriteLine("2. Payment Process");
                Console.WriteLine("3. Bill Details");
                Console.WriteLine("4. Back to Main Menu");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Want to add Bill Details? Press y to continue.");
                        string ans = Console.ReadLine();
                        while (ans.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter Patient Id, Total Amount, Payment Status(PAID/UNPAID) and Bill Date.");
                            Bill a = new Bill()
                            {
                                BillId = 0,
                                PatientId = Int32.Parse(Console.ReadLine()),
                                TotalAmount = Int32.Parse(Console.ReadLine()),
                                PaymentStatus = Console.ReadLine(),
                                BillDate = DateTime.Parse(Console.ReadLine())
                            };
                            BillBO.GenerateBill(a);
                            Console.WriteLine("Want to add another Bill? Press y to continue.");
                            ans = Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Get Payment Status");
                        Console.WriteLine("Enter Bill Id.");
                        int bilId = Int32.Parse(Console.ReadLine());
                        BillBO.ProcessPayment(bilId);
                        break;
                    case 3:
                        Console.WriteLine("Get Bill Details.");
                        Console.WriteLine("Enter BIll Id.");
                        int bilId2 = Int32.Parse(Console.ReadLine());
                        BillBO.GetBillDetails(bilId2);
                        break;
                    case 4:
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void HandleUserOperations()
        {
            while (true)
            {
                Console.WriteLine("\nUser Operations:");
                Console.WriteLine("1. User Registration");
                Console.WriteLine("2. User Profile");
                Console.WriteLine("3. Login");
                Console.WriteLine("4. Back to Main Menu");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Register as a User? Press y to continue.");
                        string cho = Console.ReadLine();
                        while (cho.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter Username, Password, and Role.");
                            User d = new User()
                            {
                                UserId = 0,
                                Username = Console.ReadLine(),
                                Password = Console.ReadLine(),
                                Role = Console.ReadLine(),
                            };
                            UserBo.AddUser(d);
                            Console.WriteLine("Want to register another User? Press y to continue.");
                            cho = Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Get User Profile");
                        Console.WriteLine("Enter ID.");
                        int userId = Int32.Parse(Console.ReadLine());
                        UserBo.GetUserProfile(userId);
                        break;
                    case 3:
                        Console.WriteLine("Get User Profile");
                        Console.WriteLine("Enter username.");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Enter password.");
                        string userPass = Console.ReadLine();
                        UserBo.UpdateUserDetails(userName, userPass);
                        break;
                    case 4:
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}