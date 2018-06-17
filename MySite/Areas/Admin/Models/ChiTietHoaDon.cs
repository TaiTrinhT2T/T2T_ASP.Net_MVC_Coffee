using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Areas.Admin.Models
{
    public class ChiTietHoaDon
    {
        public int ID_HoaDon { get; set; }
        public string NameCustomer { get; set; }
        public string NameEmployee { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string NameProduct { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}