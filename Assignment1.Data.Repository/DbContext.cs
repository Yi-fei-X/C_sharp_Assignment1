using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Assignment1.Data.Repository
{
    class DbContext
    {
        public int Execute(string cmdText, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CustomerDB;Integrated Security=True");  //unmange code
            SqlCommand cmd = new SqlCommand();  //unmanage code
            try
            {
                connection.Open();  //open the connection
                cmd.CommandText = cmdText; //"Insert into Customer values (@id, @firstname, @lastname, @mobile, @emailid, @city, @state)";
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;    //link sql command with connection string
                int r = cmd.ExecuteNonQuery();  //call this method to insert, update, delete, not for select
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return 0;
        }
        public DataTable Query(string cmdText, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CustomerDB;Integrated Security=True");  //unmange code
            SqlCommand cmd = new SqlCommand();  //unmanage code
            try
            {
                connection.Open();  //open the connection
                cmd.CommandText = cmdText; //"Insert into Customer values (@id, @firstname, @lastname, @mobile, @emailid, @city, @state)";
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;    //link sql command with connection string
                SqlDataReader reader = cmd.ExecuteReader(); //If you use sql command it will return sql reader
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return null;
        }
    }
}
