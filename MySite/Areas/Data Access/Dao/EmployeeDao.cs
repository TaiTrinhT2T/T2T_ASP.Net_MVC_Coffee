using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Areas.Data_Access.EF;
using System.Data.SqlClient;
using PagedList;

namespace MySite.Areas.Data_Access.Dao
{
    public class EmployeeDao
    {
        Model1 db = null;
        public EmployeeDao()
        {
            db = new Model1();
        }

        public int CheckLogin(string userName, string password)
        {
            object[] SqlParams =
            {
                new SqlParameter("@UserName", userName),
                 new SqlParameter("@Password", password)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Employee_Check_Login @UserName, @Password", SqlParams).SingleOrDefault();
            return result;
        }

        public IQueryable<Employee> Employee
        {
            get { return db.Employees; }
        }

        public IQueryable<Employee> ListEmployee()
        {
            var res = (from s in db.Employees
                       select s);
            return res;
        }

        public int InsertEmployee(string Role, string Name, string Email, string phone, string Status, string Pass)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@Role", Role),
                 new SqlParameter("@Name", Name),
                 new SqlParameter("@Email", Email),
                 new SqlParameter("@Telephone", phone),
                 new SqlParameter("@Status", Status),
                 new SqlParameter("@Password", Pass)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Employee_Create @Role, @Name, @Email, @Telephone, @Status, @Password", SqlParams).SingleOrDefault();
            return result;
        }

        public void DeleteEmployee(int id)
        {
            Employee epDL = db.Employees.Find(id);
            if (epDL != null)
            {
                db.Employees.Remove(epDL);
                db.SaveChanges();
            }
        }

        public int UpdateEmployee(int id, string Role, string Name, string Email, string Phone, string Status, string Pass)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@ID", id),
                 new SqlParameter("@Role", Role),
                 new SqlParameter("@Name", Name),
                 new SqlParameter("@Email", Email),
                 new SqlParameter("@Telephone", Phone),
                 new SqlParameter("@Status", Status),
                 new SqlParameter("@Password", Pass)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Employee_Update @ID, @Role, @Name, @Email, @Telephone, @Status, @Password", SqlParams).SingleOrDefault();
            return result;
        }

        public Employee FindEmployee(int id)
        {
            return db.Employees.Find(id);
        }

        public IPagedList<Employee> ListAllPaging(int page, int pageSize)
        {
            return db.Employees.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
