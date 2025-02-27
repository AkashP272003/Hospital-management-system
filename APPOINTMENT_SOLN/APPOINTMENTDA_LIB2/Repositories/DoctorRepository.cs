using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTDA_LIB2.Models;

namespace APPOINTMENTDA_LIB2.Repositories
{
    public class DoctorRepository
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN487249\\SQLEXPRESS;Initial Catalog=HMS;Integrated Security=True;";
            }
        }
        public bool Add(Doctor doc)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Doctor VALUES (@P1, @P2, @P3, @P4)", con);
                cmd.Parameters.AddWithValue("@P1", doc.Name);
                cmd.Parameters.AddWithValue("@P2", doc.Specialization);
                cmd.Parameters.AddWithValue("@P3", doc.ContactNumber);
                cmd.Parameters.AddWithValue("@P4", doc.AvailabailtySchedule);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert operation failure, Cannot add Doctor details.");
                b = false;
            }
            return b;
        }

        public bool Delete(Doctor entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Doctor WHERE doctorId=@P", con);
                cmd.Parameters.AddWithValue("@P", entity.DoctorId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete operation failure, Cannot delete Doctor details.");
                b = false;
            }
            return b;
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Doctor", con);
            SqlDataReader sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                Doctor doctor = new Doctor()
                {
                    DoctorId = Int32.Parse(sqlDr[0].ToString()),
                    Name = sqlDr[1].ToString(),
                    Specialization = sqlDr[2].ToString(),
                    ContactNumber = sqlDr[3].ToString(),
                    AvailabailtySchedule = sqlDr[4].ToString()
                };
                doctors.Add(doctor);
            }
            sqlDr.Close();
            return doctors;
        }

        public Doctor GetById(object id)
        {
            if (id == null)
            {
                return null;
            }

            if (int.TryParse(id.ToString(), out int docId)) // Try to parse
            {
                // Conversion successful, use docId
                Doctor docObj = GetAll().Where(d => d.DoctorId == docId).FirstOrDefault();
                return docObj;
            }
            else
            {
                // Conversion failed (invalid input)
                Console.WriteLine("Invalid Doctor ID format.");
                return null; // Or throw a custom exception
            }
        }



        public bool Update(Doctor doc)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Doctor SET name=@P2,specialization=@P3,contactNumber=@P4,availabilitySchedule=@P5 WHERE doctorId=@P1", con);
                cmd.Parameters.AddWithValue("@P2", doc.Name);
                cmd.Parameters.AddWithValue("@P3", doc.Specialization);
                cmd.Parameters.AddWithValue("@P4", doc.ContactNumber);
                cmd.Parameters.AddWithValue("@P5", doc.AvailabailtySchedule);
                cmd.Parameters.AddWithValue("@P1", doc.DoctorId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot update Doctor details.");
                b = false;
            }
            return b;
        }
    }
}
