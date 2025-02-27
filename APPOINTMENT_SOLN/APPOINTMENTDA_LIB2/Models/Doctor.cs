using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPOINTMENTDA_LIB2.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string AvailabailtySchedule { get; set; }
        public override string ToString()
        {
            return string.Format($"{DoctorId, 10}{Name, 20}{Specialization, 20}{ContactNumber, 15}{AvailabailtySchedule, 10}");
        }
    }
}
