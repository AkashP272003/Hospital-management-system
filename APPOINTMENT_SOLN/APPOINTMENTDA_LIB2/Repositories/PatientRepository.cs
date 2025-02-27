using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTDA_LIB2.Models;

namespace APPOINTMENTDA_LIB2.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN487249\\SQLEXPRESS;Initial Catalog=HMS;Integrated Security=True;";
            }
        }
        public bool Add(Patient pat)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Patient (name, dateOfBirth, gender, contactNumber, address, medicalHistory) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)", con);
                cmd.Parameters.AddWithValue("@P1", pat.Name);
                cmd.Parameters.AddWithValue("@P2", pat.DateOfBirth);
                cmd.Parameters.AddWithValue("@P3", pat.Gender);
                cmd.Parameters.AddWithValue("@P4", pat.ContactNumber);
                cmd.Parameters.AddWithValue("@P5", pat.Address);
                cmd.Parameters.AddWithValue("@P6", pat.MedicalHistory);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert operation failure, Cannot add Patient details.");
                b = false;
            }
            return b;
        }

        public bool Delete(Patient entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Patient WHERE patientId=@P", con);
                cmd.Parameters.AddWithValue("@P", entity.PatientId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete operation failure, Cannot delete Patient details.");
                b = false;
            }
            return b;
        }

        public List<Patient> GetAll()
        {
            List<Patient> patients = new List<Patient>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Patient", con);
            SqlDataReader sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                Patient patient = new Patient()
                {
                    PatientId = Int32.Parse(sqlDr[0].ToString()),
                    Name = sqlDr[1].ToString(),
                    DateOfBirth = sqlDr.GetDateTime(2),
                    Gender = sqlDr[3].ToString(),
                    ContactNumber = sqlDr[4].ToString(),
                    Address = sqlDr[5].ToString(),
                    MedicalHistory = sqlDr[6].ToString()
                };
                patients.Add(patient);
            }
            sqlDr.Close();
            return patients;
        }

        public Patient GetById(object id)
        {
            if (id == null)  // Always check for null first!
            {
                return null; // Or throw ArgumentNullException if appropriate
            }

            if (int.TryParse(id.ToString(), out int patId))
            {
                // Conversion successful, use patId
                Patient patObj = GetAll().Where(p => p.PatientId == patId).FirstOrDefault();
                return patObj;
            }
            else
            {
                // Conversion failed (invalid input)
                Console.WriteLine($"Invalid Patient ID format: {id}"); // Log the invalid input
                return null; // Or throw a custom exception, or handle it differently
            }
        }

        public bool Update(Patient pat)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Patient SET name=@P2,dateOfBirth=@P3,gender=@P4,contactNumber=@P5,address=@P6,medicalHistory=@P7 WHERE patientId=@P1", con);
                cmd.Parameters.AddWithValue("@P2", pat.Name);
                cmd.Parameters.AddWithValue("@P3", pat.DateOfBirth);
                cmd.Parameters.AddWithValue("@P4", pat.Gender);
                cmd.Parameters.AddWithValue("@P5", pat.ContactNumber);
                cmd.Parameters.AddWithValue("@P6", pat.Address);
                cmd.Parameters.AddWithValue("@P7", pat.MedicalHistory);
                cmd.Parameters.AddWithValue("@P1", pat.PatientId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot modify Patient details.");
                b = false;
            }
            return b;
        }
    }
}
