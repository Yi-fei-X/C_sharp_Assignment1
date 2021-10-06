using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Assignment1.Data.Repository
{
    class DbContext
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=CustomerDB;Integrated Security=True");
        } 
    }
}
