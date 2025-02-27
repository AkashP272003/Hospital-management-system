using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APPOINTMENTDA_LIB2.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BillDate { get; set; }
        public override string ToString()
        {
            return string.Format($"{BillId,10}{PatientId,10}{TotalAmount,10}{PaymentStatus,10}{BillDate,15}");
        }

    }
}
