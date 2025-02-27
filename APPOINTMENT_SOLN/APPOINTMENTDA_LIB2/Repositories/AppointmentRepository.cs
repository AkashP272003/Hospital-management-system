using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTDA_LIB2.Models;

namespace APPOINTMENTDA_LIB2.Repositories
{
    public class AppointmentRepository
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN487249\\SQLEXPRESS;Initial Catalog=HMS;Integrated Security=True;";
            }
        }
        public bool Add(Appointment appo)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(patientId, doctorId, appointmentDate, timeSlot, status) VALUES(@P1, @P2, @P3, @P4, @P5)", con);
                cmd.Parameters.AddWithValue("@P1", appo.PatientId);
                cmd.Parameters.AddWithValue("@P2", appo.DoctorId);
                cmd.Parameters.AddWithValue("@P3", appo.AppointmentDate);
                cmd.Parameters.AddWithValue("@P4", appo.TimeSlot);
                cmd.Parameters.AddWithValue("@P5", appo.Status);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert operation failure, Cannot make Appointment.");
                b = false;
            }
            return b;
        }

        public bool Delete(Appointment entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Appointment WHERE appointmentId=@P", con);
                cmd.Parameters.AddWithValue("@P", entity.AppointmentId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete operation failure, Cannot delete Appointment details.");
                b = false;
            }
            return b;
        }

        
        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = new List<Appointment>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM APPOINTMENT", con);
            SqlDataReader sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                Appointment appointment = new Appointment()
                {
                    AppointmentId = Int32.Parse(sqlDr[0].ToString()),
                    PatientId = Int32.Parse(sqlDr[1].ToString()),
                    DoctorId = Int32.Parse(sqlDr[2].ToString()),
                    AppointmentDate = DateTime.Parse(sqlDr[3].ToString()),
                    TimeSlot = sqlDr[4].ToString(),
                    Status = sqlDr[5].ToString()
                };
                appointments.Add(appointment);
            }
            sqlDr.Close();
            return appointments;
        }


        public Appointment GetById(object id)
        {
            if (id == null)
            {
                return null; // Or throw ArgumentNullException
            }

            if (int.TryParse(id.ToString(), out int appoId))
            {
                // Conversion successful, use appoId
                Appointment appoObj = GetAll().Where(a => a.AppointmentId == appoId).FirstOrDefault();
                return appoObj;
            }
            else
            {
                // Conversion failed (invalid input)
                Console.WriteLine($"Invalid Appointment ID format: {id}"); // Log the error
                return null; // Or throw a custom exception
            }
        }

        public bool Update(Appointment appo)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Appointment SET patientId=@P2,doctorId=@P3, appointmentDate=@P4, timeSlot=@P5, status=@P6 WHERE ID=@P1", con);
                cmd.Parameters.AddWithValue("@P2", appo.PatientId);
                cmd.Parameters.AddWithValue("@P3", appo.DoctorId);
                cmd.Parameters.AddWithValue("@P4", appo.AppointmentDate);
                cmd.Parameters.AddWithValue("@P5", appo.TimeSlot);
                cmd.Parameters.AddWithValue("@P6", appo.Status);
                cmd.Parameters.AddWithValue("@P1", appo.AppointmentId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot modify Appointment details.");
                b = false;
            }
            return b;
        }
        
    }
}
