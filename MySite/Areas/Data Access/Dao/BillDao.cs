using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Areas.Data_Access.EF;
using System.Data.SqlClient;
using MySite.Areas.Admin.Models;
using PagedList;

namespace MySite.Areas.Data_Access.Dao
{
    public class BillDao
    {
        Model1 db = null;
        public BillDao()
        {
            db = new Model1();
        }

        public List<HoaDon> ListBillAll()
        {
            var exProc = db.Database.SqlQuery<HoaDon>("exec Bill_SelectAllBill").ToList();

            return exProc;
        }

        public List<ChiTietHoaDon> ListBillDetails(int id)
        {
            var exProc = db.Database.SqlQuery<ChiTietHoaDon>("exec Bill_DetailBill @idBill",
               new SqlParameter("@idBill", id)
               ).ToList();
            return exProc;
        }

        public int InsertBill(
            int idProduct, 
            int idEmployee, 
            DateTime date, 
            int total, 
            int quantity, 
            string name, 
            string address, 
            string email, 
            string phone)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@idProduct", idProduct),
                 new SqlParameter("@idEmployee", idEmployee),
                 new SqlParameter("@date", date),
                 new SqlParameter("@total", total),
                 new SqlParameter("@quantity", quantity),
                 new SqlParameter("@name", name),
                 new SqlParameter("@address", address),
                 new SqlParameter("@email", email),
                 new SqlParameter("@phone", phone)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Bill_Create @idProduct, @idEmployee, @date, @total, @quantity, @name, @address, @email, @phone", SqlParams).SingleOrDefault();
            return result;
        }

        public int DeleteBill(int id)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@idBill", id)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Bill_Delete @idBill", SqlParams).SingleOrDefault();
            return result;
        }
    }
}