using System;
using System.Collections.Generic;
using System.Data;
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
            string cmd = "select id, firstname, lastname, mobile, emailid, city, state from Customer";
            List<Customer> lstCollection = new List<Customer>();
            DataTable dt = db.Query(cmd);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Customer c = new Customer();
                    c.Id = Convert.ToInt32(item["id"]);
                    c.FirstName = Convert.ToString(item["firstname"]);
                    c.LastName = Convert.ToString(item["lastname"]);
                    c.Mobile = Convert.ToInt32(item["mobile"]);
                    c.EmailId = Convert.ToString(item["emailid"]);
                    c.City = Convert.ToString(item["city"]);
                    c.State = Convert.ToString(item["state"]);
                    lstCollection.Add(c);
                }
            }
            return lstCollection;
        }

        public Customer GetById(int id)
        {
            string cmd = "select id, firstname, lastname, mobile, emailid, city, state from Customer where id=@id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id", id);
            DataTable dt = db.Query(cmd, p);
            if(dt != null && dt.Rows.Count > 0)
            {
                Customer c = new Customer();
                DataRow dr = dt.Rows[0];
                c.Id = Convert.ToInt32(dr["id"]);
                c.FirstName = Convert.ToString(dr["firstname"]);
                c.LastName = Convert.ToString(dr["lastname"]);
                c.Mobile = Convert.ToInt32(dr["mobile"]);
                c.EmailId = Convert.ToString(dr["emailid"]);
                c.City = Convert.ToString(dr["city"]);
                c.State = Convert.ToString(dr["state"]);
                return c;
            }
            return null;
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
