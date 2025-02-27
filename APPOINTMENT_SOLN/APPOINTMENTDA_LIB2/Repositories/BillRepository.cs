using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPOINTMENTDA_LIB2.Models;

namespace APPOINTMENTDA_LIB2.Repositories
{
    public class BillRepository : IRepository<Bill>
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN487249\\SQLEXPRESS;Initial Catalog=HMS;Integrated Security=True;";
            }
        }

        public bool Add(Bill bil)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Bill (patientId, totalAmount, paymentStatus, billDate) VALUES (@P1, @P2, @P3, @P4)", con);
                cmd.Parameters.AddWithValue("@P1", bil.PatientId);
                cmd.Parameters.AddWithValue("@P2", bil.TotalAmount);
                cmd.Parameters.AddWithValue("@P3", bil.PaymentStatus);
                cmd.Parameters.AddWithValue("@P4", bil.BillDate);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert operation failure, Cannot add Bill details.");
                b = false;
            }
            return b;
        }

        public bool Delete(Bill entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Bill WHERE billId=@P", con);
                cmd.Parameters.AddWithValue("@P", entity.BillId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete operation failure, Cannot delete Bill details.");
                b = false;
            }
            return b;
        }

        public List<Bill> GetAll()
        {
            List<Bill> bills = new List<Bill>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT BillId, PatientId, TotalAmount, PaymentStatus, BillDate FROM Bill", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bill bill = new Bill();

                            if (int.TryParse(reader[0].ToString(), out int billId))
                            {
                                bill.BillId = billId;
                            }
                            else
                            {
                                Console.WriteLine($"Error parsing BillId: {reader[0]}");
                                continue;
                            }

                            bill.PatientId = reader.GetInt32(1);
                            bill.PaymentStatus = reader.GetString(3);
                            bill.BillDate = reader.GetDateTime(4);

                            // Corrected: Use GetDecimal for TotalAmount
                            bill.TotalAmount = reader.GetDecimal(2);  // Or reader.GetSqlDecimal(2) if using SqlDecimal

                            bills.Add(bill);
                        }
                    }
                }
            }
            return bills;
        }

        public Bill GetById(object id)
        {
            int bilId = (int)id;
            Bill bilObj = GetAll().Where(p => p.BillId == bilId).FirstOrDefault();
            return bilObj;
        }

        public BillInfo GetBillInfoById(object id)
        {
            if (id == null)
            {
                return null;
            }

            if (int.TryParse(id.ToString(), out int bilId))
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT BillId, PaymentStatus FROM Bill WHERE BillId = @BillId", con))
                    {
                        cmd.Parameters.AddWithValue("@BillId", bilId); // Use parameters!
                        using (SqlDataReader sqlDr = cmd.ExecuteReader())
                        {
                            if (sqlDr.Read()) // Only one row expected
                            {
                                BillInfo billInfo = new BillInfo
                                {
                                    BillId = sqlDr.GetInt32(0), // Direct access, safer
                                    PaymentStatus = sqlDr.GetString(1) // Direct access, safer
                                };
                                return billInfo;
                            }
                        }
                    }
                }
            }

            return null; // Or throw an exception if appropriate
        }

        public bool Update(Bill entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Bill SET patientId=@P2,totalAmount=@P3,paymentStatus=@P4,billDate=@P5 WHERE billId=@P1", con);
                cmd.Parameters.AddWithValue("@P2", entity.PatientId);
                cmd.Parameters.AddWithValue("@P3", entity.TotalAmount);
                cmd.Parameters.AddWithValue("@P4", entity.PaymentStatus);
                cmd.Parameters.AddWithValue("@P5", entity.BillDate);
                cmd.Parameters.AddWithValue("@P1", entity.BillId);

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot modify Bill details.");
                b = false;
            }
            return b;
        }
    }
}
