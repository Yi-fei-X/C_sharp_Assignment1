using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Data.Model;


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
            string cmd = "delete from Customer where id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.Execute(cmd, parameters);
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
            string cmd = "Insert into Customer values (@id, @firstname, @lastname, @mobile, @emailid, @city, @state)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", item.Id);
            parameters.Add("@firstname", item.FirstName);
            parameters.Add("@lastname", item.LastName);
            parameters.Add("@mobile", item.Mobile);
            parameters.Add("@emailid", item.EmailId);
            parameters.Add("@city", item.City);
            parameters.Add("@state", item.State);
            return db.Execute(cmd, parameters);
        }   

        public int Update(Customer item)
        {
            string cmd = "update customer set firstname = @firstname, lastname = @lastname, mobile = @mobile, emailid = @emailid, city = @city, state = @state where id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", item.Id);
            parameters.Add("@firstname", item.FirstName);
            parameters.Add("@lastname", item.LastName);
            parameters.Add("@mobile", item.Mobile);
            parameters.Add("@emailid", item.EmailId);
            parameters.Add("@city", item.City);
            parameters.Add("@state", item.State);
            return db.Execute(cmd, parameters);
        }
    }
}
