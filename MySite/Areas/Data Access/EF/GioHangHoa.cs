using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MySite.Areas.Data_Access.EF
{
    public class GioHangHoa
    {
        private List<HangHoaBan> listHangHoa = new List<HangHoaBan>();
        public GioHangHoa()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void addHangHoa(HangHoaBan tmp)
        {
            //bool co = false;
            //foreach (HangHoaBan i in listHangHoa)
            //    if (i.id == tmp.id) //Already exists
            //    {
            //        i.sl += tmp.sl;
            //        co = true;
            //        break;
            //    }
            //if (!co)
            //    listHangHoa.Add(tmp);
        }

        public void updateHangHoa(HangHoaBan tmp)
        {
            //foreach (HangHoaBan i in listHangHoa)
            //    if (i.id == tmp.id)
            //    {
            //        i.sl = tmp.sl;
            //        if (tmp.sl == 0)
            //            listHangHoa.Remove(tmp);
            //        return;
            //    }
        }

        public void deleteHangHoa(int id)
        {
            //foreach (HangHoaBan i in listHangHoa)
            //    if (i.id == id)
            //        listHangHoa.Remove(i);
        }

        public int getSL()
        {
            int sll = 0;
            foreach (HangHoaBan i in listHangHoa)
                sll += i.sl;
            return sll;

        }
        public int getTongTien()
        {
            int tong = 0;
            foreach (HangHoaBan i in listHangHoa)
                tong += i.sl * i.price;
            return tong;
        }

        //public DataTable returnTable()
        //{

        //    //DataTable tbl = new DataTable();
        //    //tbl.Columns.Add("id");
        //    //tbl.Columns.Add("name");
        //    //tbl.Columns.Add("price");
        //    //tbl.Columns.Add("sl");
        //    //tbl.Columns.Add("thanhtien");

        //    //foreach (HangHoaBan i in listHangHoa)
        //    //{
        //    //    DataRow dr = tbl.NewRow();
        //    //    dr["id"] = i.id;
        //    //    dr["name"] = "abc";
        //    //    dr["price"] = 100;
        //    //    dr["sl"] = i.sl;
        //    //    dr["thanhtien"] = (i.sl) * 100;
        //    //    tbl.Rows.Add(dr);
        //    //}
        //    //return tbl;
        //}
    }
}