using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GuildCars.Data
{
    public class PurchaseRepositoryADO: IPurchaseRepository
    {
        public void SaveCustomerInfo(Customer customerinfo)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SaveCustomerInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CustomerId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@FirstName", customerinfo.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customerinfo.LastName);
                cmd.Parameters.AddWithValue("@City", customerinfo.City);
                cmd.Parameters.AddWithValue("@Email", customerinfo.Email);
                cmd.Parameters.AddWithValue("@Phone", customerinfo.Phone);
                cmd.Parameters.AddWithValue("@Zip", customerinfo.Zip);
                cmd.Parameters.AddWithValue("@Street1", customerinfo.Street1);
                if (string.IsNullOrEmpty(customerinfo.Street2))
                {
                    cmd.Parameters.AddWithValue("@Street2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Street2", customerinfo.Street2);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                customerinfo.CustomerId = (int)param.Value;

            }


        }

        public void SavePurchase(SalesReciepts sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SavePurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SalesReceiptId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@VehicleId", sale.VehicleId);
                cmd.Parameters.AddWithValue("@CustomerId", sale.CustomerId);

                cmd.Parameters.AddWithValue("@EmployeeId", sale.EmployeeId);
                cmd.Parameters.AddWithValue("@PaymentMethodId", sale.PaymentMethodId);
                cmd.Parameters.AddWithValue("@Total", sale.Total);
                cmd.Parameters.AddWithValue("@Date", sale.Date);

                cn.Open();

                cmd.ExecuteNonQuery();

                sale.SalesRecieptsId = (int)param.Value;
            }
                
        }

        public void PurchaseVehicle(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseVehicle", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", id);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<PaymentMethod> GetAllPaymentTypes()
        {
            List<PaymentMethod> methods = new List<PaymentMethod>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllPaymentTypes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PaymentMethod currentRow = new PaymentMethod();
                        currentRow.PaymentMethodId = (int)dr["PaymentMethodId"];
                        currentRow.PaymentName = dr["PaymentName"].ToString();

                        methods.Add(currentRow);

                    }
                }
            }

            return methods;
        }


    }
}
