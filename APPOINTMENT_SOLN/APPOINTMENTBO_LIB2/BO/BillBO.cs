using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTBO_LIB2.Models;
using APPOINTMENTDA_LIB2.Repositories;

namespace APPOINTMENTBO_LIB2.BO
{
    public class BillBO
    {
        static BillRepository bilRep = new BillRepository();

        public static void GetBillDetails(int billId)
        {
            var bill = bilRep.GetById(billId);
            if (bill == null)
            {
                Console.WriteLine("Bill Id is invalid, Could not find Bill details.");
            }
            else
            {
                Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}", "Bill Id", "Patient Id", "Total Amount", "Payment Status", "Bill Date");
                Console.WriteLine(bill);
            }
        }

        public static void ProcessPayment(int billId)
        {
            var bill = bilRep.GetBillInfoById(billId);
            if (bill == null)
            {
                Console.WriteLine("Bill Id is invalid, Could not find Bill details.");
            }
            else
            {
                Console.WriteLine("{0,10}{1,10}", "Bill Id", "Payment Status");
                Console.WriteLine(bill);
            }
        }

        public static void GenerateBill(Bill bil)
        {
            APPOINTMENTDA_LIB2.Models.Bill bill = new APPOINTMENTDA_LIB2.Models.Bill();
            bill.BillId = bil.BillId;
            bill.PatientId = bil.PatientId;
            bill.TotalAmount = bil.TotalAmount;
            bill.PaymentStatus = bil.PaymentStatus;
            bill.BillDate = bil.BillDate;
            bool b = bilRep.Add(bill);
            if (b)
            {
                Console.WriteLine("Bill details added.");
            }
            else
            {
                Console.WriteLine("Insert operation failure.");
            }

        }





    }
}
