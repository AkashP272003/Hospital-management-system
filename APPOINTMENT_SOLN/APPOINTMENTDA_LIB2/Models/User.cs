using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APPOINTMENTDA_LIB2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public override string ToString()
        {
            return string.Format($"{UserId,10}{Username,20}{Password,15}{Role,10}");
        }
    }
}
