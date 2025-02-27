using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPOINTMENTBO_LIB2.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string AvailabailtySchedule { get; set; }
    }
}
