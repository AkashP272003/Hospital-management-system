/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APPOINTMENTBO_LIB2.BO;
using APPOINTMENTBO_LIB2.Models;


namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("01. Add Doctor Details");
                Console.WriteLine("02. Update Doctor Details");
                Console.WriteLine("03. Search Doctor Details");
                
                Console.WriteLine("04. Add Patient Details");
                Console.WriteLine("05. Modify Patient Details");
                Console.WriteLine("06. Search Patient Details");
                Console.WriteLine("07. Delete Patient Details");

                Console.WriteLine("08. Make Appointment");
                Console.WriteLine("09. Search Appointment");
                Console.WriteLine("10. Delete Appointment");


                Console.WriteLine("11. User Registration");
                Console.WriteLine("12. User Profile");
                Console.WriteLine("13. Login");


                Console.WriteLine("14. Add Bill Details ");
                Console.WriteLine("15. Payment Process");
                Console.WriteLine("16. Bill Details");


                Console.WriteLine("17. Exit");

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
                        Console.WriteLine("Want to add Patient details? Press y to continue.");
                        ans = Console.ReadLine();
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
                    case 5:
                        Console.WriteLine("Updating a particular Patient.");
                        Console.WriteLine("Enter Patient ID.");
                        int patId3 = Int32.Parse(Console.ReadLine());
                        PatientBO.UpdatePatient(patId3);
                        break;
                    case 6:
                        Console.WriteLine("Searching a particular Patient.");
                        Console.WriteLine("Enter Patient ID.");
                        int patId = Int32.Parse(Console.ReadLine());
                        PatientBO.GetPatientDetails(patId);
                        break;
                    case 7:
                        Console.WriteLine("Deleting a particular Patient.");
                        Console.WriteLine("Enter Patient ID.");
                        int patId2 = Int32.Parse(Console.ReadLine());
                        PatientBO.DeletePatient(patId2);
                        break;
                        

                    case 8:
                        Console.WriteLine("Want to make an appointment? Press y to continue.");
                        ans = Console.ReadLine();
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
                    case 9:
                        Console.WriteLine("Searching an appointment");
                        Console.WriteLine("Enter ID.");
                        int appoId = Int32.Parse(Console.ReadLine());
                        AppointmentBO.GetAppointmentDetails(appoId);
                        break;
                    case 10:
                        Console.WriteLine("Deleting an appointment.");
                        Console.WriteLine("Enter ID.");
                        int appoId2 = Int32.Parse(Console.ReadLine());
                        AppointmentBO.CancelAppointment(appoId2);
                        break;


                    case 11:
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
                    case 12:
                        Console.WriteLine("Get User Profile");
                        Console.WriteLine("Enter ID.");
                        int userId = Int32.Parse(Console.ReadLine());
                        UserBo.GetUserProfile(userId);
                        break;

                    case 13:
                        Console.WriteLine("Get User Profile");
                        Console.WriteLine("Enter username.");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Enter password.");
                        string userPass = Console.ReadLine();
                        UserBo.UpdateUserDetails(userName, userPass);
                        break;


                    case 14:
                        Console.WriteLine("Want to add Bill Details? Press y to continue.");
                        ans = Console.ReadLine();
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
                    case 15:
                        Console.WriteLine("Get Payment Status");
                        Console.WriteLine("Enter Bill Id.");
                        int bilId = Int32.Parse(Console.ReadLine());
                        BillBO.ProcessPayment(bilId);
                        break;

                    case 16:
                        Console.WriteLine("Get Bill Details.");
                        Console.WriteLine("Enter BIll Id.");
                        int bilId2 = Int32.Parse(Console.ReadLine());
                        BillBO.GetBillDetails(bilId2);
                        break;

                    

                    case 17:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            
            
           

            

            

            Console.Read();
        }
    }
}*/
