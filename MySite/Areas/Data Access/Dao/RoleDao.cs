using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySite.Areas.Data_Access.EF;
using System.Data.SqlClient;

namespace MySite.Areas.Data_Access.Dao
{
    public class RoleDao
    {
        Model1 db = null;
        public RoleDao()
        {
            db = new Model1();
        }

        public IQueryable<Role> ListRole()
        {
            var res = (from s in db.Roles
                       select s);
            return res;
        }

        public int InsertRole(string nameRole)
        {
            object[] sqlParams =
            {
                 new SqlParameter("@NameRole", nameRole)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Role_Create @NameRole", sqlParams).SingleOrDefault();
            return result;
        }

        public void DeleteRole(int id)
        {
            Role epDL = db.Roles.Find(id);
            if (epDL != null)
            {
                db.Roles.Remove(epDL);
                db.SaveChanges();
            }
        }

        public int UpdateRole(int id, string name)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ID", id),
                 new SqlParameter("@NameRole", name)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Role_Update @ID, @NameRole", sqlParams).SingleOrDefault();
            return result;
        }

        public Role FindRole(int id)
        {
            return db.Roles.Find(id);
        }
    }
}