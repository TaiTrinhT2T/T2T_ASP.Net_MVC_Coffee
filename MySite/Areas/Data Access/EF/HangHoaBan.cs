using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Areas.Data_Access.EF
{
    public class HangHoaBan
    {
        public HangHoaBan() { }
        public HangHoaBan(Product p, int sl)
        {
            this.product = p;
            this.sl = sl;
        }

        public int sl
        {
            get;
            set;
        }
        public Product product
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public int price
        {
            get;
            set;
        }
    }
}