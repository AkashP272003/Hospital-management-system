using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPOINTMENTDA_LIB2.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string MedicalHistory { get; set; }
        public override string ToString()
        {
            return string.Format($"{PatientId,10}{Name,20}{DateOfBirth,15}{Gender,5}{ContactNumber,15}{Address,30}{MedicalHistory,25}");
        }
    }
}
