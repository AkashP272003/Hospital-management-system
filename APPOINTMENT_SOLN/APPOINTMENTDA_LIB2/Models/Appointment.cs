using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APPOINTMENTDA_LIB2.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return string.Format($"{AppointmentId,20}{PatientId,15}{DoctorId,10}{AppointmentDate,25}{TimeSlot,10}{Status,10}");
        }
    }
}
