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
    public class UserRepository : IRepository<User>
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN487249\\SQLEXPRESS;Initial Catalog=HMS;Integrated Security=True;";
            }
        }
        public bool Add(User usr)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (username, password, role) VALUES (@P1, @P2, @P3)", con);
                cmd.Parameters.AddWithValue("@P1", usr.Username);
                cmd.Parameters.AddWithValue("@P2", usr.Password);
                cmd.Parameters.AddWithValue("@P3", usr.Role);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert operation failure, Cannot add User details.");
                b = false;
            }
            return b;
        }

        public bool Delete(User entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE userId=@P", con);
                cmd.Parameters.AddWithValue("@P", entity.UserId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete operation failure, Cannot delete User details.");
                b = false;
            }
            return b;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
            SqlDataReader sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                User user = new User()
                {
                    UserId = Int32.Parse(sqlDr[0].ToString()),
                    Username = sqlDr[1].ToString(),
                    Password = sqlDr[2].ToString(),
                    Role = sqlDr[3].ToString()
                };
                users.Add(user);
            }
            sqlDr.Close();
            return users;
        }

        public User GetById(object id)
        {
            if (id == null)
            {
                return null; // Or throw ArgumentNullException if appropriate
            }

            if (int.TryParse(id.ToString(), out int usrId))
            {
                // Conversion successful, use usrId
                User usrObj = GetAll().Where(u => u.UserId == usrId).FirstOrDefault();
                return usrObj;
            }
            else
            {
                // Conversion failed (invalid input)
                Console.WriteLine($"Invalid User ID format: {id}"); // Log the error
                return null; // Or throw a custom exception, or handle it differently
            }
        }

        public bool Update(User entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET username=@P2,password=@P3, role=@P4 WHERE userId=@P1", con);
                cmd.Parameters.AddWithValue("@P2", entity.Username);
                cmd.Parameters.AddWithValue("@P3", entity.Password);
                cmd.Parameters.AddWithValue("@P4", entity.Role);
                cmd.Parameters.AddWithValue("@P1", entity.UserId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot modify User details.");
                b = false;
            }
            return b;
        }

        public User GetByUsernamePassword(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            User userObj = GetAll().Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return userObj;
        }


    }
}
