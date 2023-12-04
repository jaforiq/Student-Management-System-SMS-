using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_SMS_
{
    public class SemesterAdd
    {
        public string SemisterCode { get; set; }
        public string Year { get; set; }
        public List<Course> courses { get; set; }

        public SemesterAdd()
        {
            courses = new List<Course>();
        }
    }
}
