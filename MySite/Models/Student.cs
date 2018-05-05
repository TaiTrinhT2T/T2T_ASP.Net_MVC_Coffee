using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set;}

        public static IEnumerable<Student> GetList(int Count)
        {
            var st = new List<Student>();
            for (int i = 1; i <= Count; i++)
            {
                st.Add(new Student { ID = i, Name = "Student" + i.ToString(), Age=20});
            }
            return st;
        }
    }
}