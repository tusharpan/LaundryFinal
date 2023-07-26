using Microsoft.Data.SqlClient;
using MvvmHelpers.Commands;
using System.Data;

namespace LaundryFinal.Models
{
    public class Admin
    {

        public   int Users { get; set; }
        public  int Orders { get; set; }
        public  decimal Revenue { get; set; }

        public Admin (int Users, int Orders, decimal Revenue)
        {
            this.Users = Users; 
            this.Orders = Orders;
            this.Revenue = Revenue;

        }
        public Admin() { }

        public static int getuserCount()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LaundrySystem;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TotalUser";
                //SqlDataReader dr = cmd.ExecuteReader();
                int userCount = (int)cmd.ExecuteScalar();

               return userCount;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return 0;
        }
        public static int getOrderCount()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LaundrySystem;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TotalOrders";
                //SqlDataReader dr = cmd.ExecuteReader();
                int userCount = (int)cmd.ExecuteScalar();

                return userCount;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return 0;
        }
        public static decimal getTotalRevenue()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LaundrySystem;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TotalRevenue";
                //SqlDataReader dr = cmd.ExecuteReader();
                decimal userCount = (decimal)cmd.ExecuteScalar();

                return userCount;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return 0;
        }

        public static Admin GetAdmin()
        {
            return new Admin(getuserCount(), getOrderCount(), getTotalRevenue());
        }
    }
}
