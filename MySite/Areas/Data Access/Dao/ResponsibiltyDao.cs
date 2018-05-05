using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySite.Areas.Data_Access.EF;

namespace MySite.Areas.Data_Access.Dao
{
    public class ResponsibiltyDao
    {
        Model1 db = null;
        public ResponsibiltyDao()
        {
            db = new Model1();
        }

        public IQueryable<Responsibilty> ListResponsibilty()
        {
            var res = (from s in db.Responsibilties
                       select s);
            return res;
        }

        public int InsertResponsibilty(string name, string description)
        {
            object[] sqlParams =
            {
                 new SqlParameter("@Name", name),
                 new SqlParameter("@Description", description)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Responsibilty_Create @Name, @Description", sqlParams).SingleOrDefault();
            return result;
        }

        public void DeleteResponsibilty(int id)
        {
            Responsibilty epDL = db.Responsibilties.Find(id);
            if (epDL != null)
            {
                db.Responsibilties.Remove(epDL);
                db.SaveChanges();
            }
        }

        public int UpdateResponsibilty(int id, string name, string description)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ID", id),
                 new SqlParameter("@Name", name),
                 new SqlParameter("@Description", description)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Responsibilty_Update @ID, @Name, @Description", sqlParams).SingleOrDefault();
            return result;
        }

        public Responsibilty FindResponsibilty(int id)
        {
            return db.Responsibilties.Find(id);
        }
    }
}