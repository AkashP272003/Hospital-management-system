using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTBO_LIB2.Models;
using APPOINTMENTDA_LIB2.Repositories;

namespace APPOINTMENTBO_LIB2.BO
{
    public class UserBo
    {
        static UserRepository userRep = new UserRepository();

        public static void AddUser(User usr)
        {
            APPOINTMENTDA_LIB2.Models.User user = new APPOINTMENTDA_LIB2.Models.User();
            user.UserId = usr.UserId;
            user.Username = usr.Username;
            user.Password = usr.Password;
            user.Role = usr.Role;
            bool b = userRep.Add(user);
            if (b)
            {
                Console.WriteLine("User registered successfully.");
            }
            else
            {
                Console.WriteLine("Registration failed.");
            }

        }

        public static void GetUserProfile(int userId)
        {
            var user = userRep.GetById(userId);
            if (user == null)
            {
                Console.WriteLine("User ID is invalid, Could not find User profile.");
            }
            else
            {
                Console.WriteLine("{0,10}{1,20}{2,15}{3,5}", "User ID", "Username", "Password", "Role");
                Console.WriteLine(user);
            }
        }

        public static void LoginUser(string userName, string userPass)
        {
            var user = userRep.GetByUsernamePassword(userName,userPass);
            if (user == null)
            {
                Console.WriteLine("User credentials are invalid, Could not find User profile.");
            }
            else
            {
                Console.WriteLine("{0,10}{1,20}{2,15}{3,5}", "User ID", "Username", "Password", "Role");
                Console.WriteLine(user);
            }
        }

        public static void UpdateUserDetails(string userName, string userPass)
        {
            var user = userRep.GetByUsernamePassword(userName, userPass);
            if (user == null)
            {
                Console.WriteLine("credentials is invalid, Could not find user.");
            }
            else
            {
                Console.WriteLine("Renter UserName, Password, Role");
                APPOINTMENTDA_LIB2.Models.User u = new APPOINTMENTDA_LIB2.Models.User()
                {
                    UserId = user.UserId,
                    Username = Console.ReadLine(),
                    Password = Console.ReadLine(),
                    Role = Console.ReadLine(),
                };
                bool b = userRep.Update(u);
                if (b)
                {
                    Console.WriteLine("User details updated.");
                }
                else
                {
                    Console.WriteLine("Update operation failure.");
                }
            }
        }




    }
}
