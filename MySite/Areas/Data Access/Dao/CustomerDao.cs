using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Areas.Data_Access.EF;
using System.Data.SqlClient;

namespace MySite.Areas.Data_Access.Dao
{
    public class CustomerDao
    {
        Model1 db = null;
        public CustomerDao()
        {
            db = new Model1();
        }

        public IQueryable<Customer> ListCustomer()
        {
            var res = (from s in db.Customers
                       select s);
            return res;
        }

        public int InsertCustomer(string name, string address, string email, string phone)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@name", name),
                 new SqlParameter("@address", address),
                 new SqlParameter("@email", email),
                 new SqlParameter("@phone", phone)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Customer_Create @name, @address, @email, @phone", SqlParams).SingleOrDefault();
            return result;
        }

        public void DeleteCustomer(int id)
        {
            Customer epDL = db.Customers.Find(id);
            if (epDL != null)
            {
                db.Customers.Remove(epDL);
                db.SaveChanges();
            }
        }

        public int UpdateCustomer(int id, string name, string address, string email, string phone)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@ID", id),
                 new SqlParameter("@name", name),
                 new SqlParameter("@address", address),
                 new SqlParameter("@email", email),
                 new SqlParameter("@phone", phone)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Customer_Update @ID, @name, @address, @email, @phone", SqlParams).SingleOrDefault();
            return result;
        }

        public Customer FindCustomer(int id)
        {
            return db.Customers.Find(id);
        }
    }
}