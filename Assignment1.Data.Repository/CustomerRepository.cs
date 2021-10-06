using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Data.Model;
using System.Data.SqlClient;

namespace Assignment1.Data.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        DbContext db;
        public CustomerRepository()
        {
            db = new DbContext();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Customer item)
        {
            SqlConnection connection = db.GetConnection();  //unmange code
            SqlCommand cmd = new SqlCommand();  //unmanage code
            try
            {
                connection.Open();  //open the connection
                cmd.CommandText = "Insert into Customer values (@id, @firstname, @lastname, @mobile, @emailid, @city, @state)";
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@firstname", item.FirstName);
                cmd.Parameters.AddWithValue("@lastname", item.LastName);
                cmd.Parameters.AddWithValue("@mobile", item.Mobile);
                cmd.Parameters.AddWithValue("@emailid", item.EmailId);
                cmd.Parameters.AddWithValue("@city", item.City);
                cmd.Parameters.AddWithValue("@state", item.State);
                cmd.Connection = connection;    //link sql command with connection string
                int r = cmd.ExecuteNonQuery();  //call this method to insert, update, delete, not for select
                return r;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
                connection.Dispose();   //remove object of unmanage code
                cmd.Dispose();
            }
            return 0;
        }   

        public int Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
