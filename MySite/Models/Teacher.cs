using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public static IEnumerable<Teacher> getAll (int n)// chú ý khai báo biến cho đúng
        {
            List<Teacher> Is = new List<Teacher>();
            for (int i=0;i<n;i++)
            {
                Teacher tch = new Teacher();
                tch.id = i + 1;
                tch.name = "Teacher" + (i + 1);
                tch.email = "Email" + (i + 1);
                Is.Add(tch);
            }
            return Is; 
            // Sau này tất cả chỗ này sẽ lấy từ CSDL ra
        }
    }
}