using Microsoft.Data.SqlClient;
using System.Data;

namespace LaundryFinal.Models
{
    public class DAO
    {


        public static User Login(String Email, String Password)
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
                cmd.CommandText = "Login";

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@password", Password);


               SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                  return   new User("",Email,Password,dr.GetInt32("Id"),dr.GetBoolean("is_admin"));
                    
                }
                else {

                    return null;
                }

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                return null;
                Console.WriteLine(ex.Message);
            }
            finally
            {    
                cn.Close();
            }
        }

        public static void PlaceOrder(int Shirt, int pant, int suit, String del_address, int user_id)
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
                cmd.CommandText = "CreateOrder";
                decimal Amount = 20 * Shirt + 20 * pant + 50 * suit;

                cmd.Parameters.AddWithValue("@Shirts", Shirt);
                cmd.Parameters.AddWithValue("@pants", pant);
                cmd.Parameters.AddWithValue("@suits", suit);
                cmd.Parameters.AddWithValue("@del_address", del_address);
                cmd.Parameters.AddWithValue("@User_id", user_id);
                cmd.Parameters.AddWithValue("@Amount", Amount);


                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        public static void Register(String Name, String Email, String Password)
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
                cmd.CommandText = "Register";

                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);


                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        public static List<Order> GetOrders(int User_id)
        {
           
            List<Order> orders = new List<Order>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=LaundrySystem;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUserOrder";

                cmd.Parameters.AddWithValue("@User_id", User_id);



                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //int User_id, int Shirts, int Pants, int Suits, decimal Amount , String  Del_address
                    orders.Add(new Order(dr.GetInt32("User_id"), dr.GetInt32("Shirts"), dr.GetInt32("Pants"), dr.GetInt32("Suits"), dr.GetDecimal("Amount"), dr.GetString("Del_address"),dr.GetInt32("Order_Id")));
                }

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return orders;
        }

        public static void cancelOrder (int order_id)
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
                cmd.CommandText = "cancelOrder";

                cmd.Parameters.AddWithValue("@order_id", order_id);
                


                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        public static Order GetOrder(int Order_id)
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
                cmd.CommandText = "Orderbyid";

                cmd.Parameters.AddWithValue("@Order_id", Order_id);



                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //int User_id, int Shirts, int Pants, int Suits, decimal Amount , String  Del_address
                  return  new Order(dr.GetInt32("User_id"), dr.GetInt32("Shirts"), dr.GetInt32("Pants"), dr.GetInt32("Suits"), dr.GetDecimal("Amount"), dr.GetString("Del_address"), dr.GetInt32("Order_Id"));
                }

              
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return null;
        }

        public static void makeadmin(int order_id)
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
                cmd.CommandText = "makeadmin";

                



                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

       
    }
}
