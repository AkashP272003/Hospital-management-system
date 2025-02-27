using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPOINTMENTDA_LIB2.Models
{
    public class BillInfo
    {
        public int BillId { get; set; }
        public string PaymentStatus { get; set; }

        public override string ToString()
        {
            return string.Format($"{BillId,10}{PaymentStatus,10}");
        }
    }
}
