using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Areas.Data_Access.EF;
using System.Data.SqlClient;

namespace MySite.Areas.Data_Access.Dao
{
    public class ProductDao
    {
        Model1 db = null;
        public ProductDao()
        {
            db = new Model1();
        }

        public IQueryable<Product> ListProduct()
        {
            var res = (from s in db.Products
                       select s);
            return res;
        }

        public int InsertProduct(string name, string detail, int? price, string image)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@name", name),
                 new SqlParameter("@detail", detail),
                 new SqlParameter("@price", price),
                 new SqlParameter("@image", image)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Product_Create @name, @detail, @price, @image", SqlParams).SingleOrDefault();
            return result;
        }

        public void DeleteProduct(int id)
        {
            Product epDL = db.Products.Find(id);
            if (epDL != null)
            {
                db.Products.Remove(epDL);
                db.SaveChanges();
            }
        }

        public int UpdateProduct(int id, string name, string detail, int? price, string image)
        {
            object[] SqlParams =
            {
                 new SqlParameter("@ID", id),
                  new SqlParameter("@name", name),
                 new SqlParameter("@detail", detail),
                 new SqlParameter("@price", price),
                 new SqlParameter("@image", image)
            };
            // Dây là câu lệnh để tương tác trực tiếp với SQL thông qua Store Procedure trong SQL
            int result = db.Database.SqlQuery<int>
                ("Product_Update @ID, @name, @detail, @price, @image", SqlParams).SingleOrDefault();
            return result;
        }

        public Product FindProduct(int id)
        {
            return db.Products.Find(id);
        }
    }
}