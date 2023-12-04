using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_SMS_
{
    public interface IStudent
    {
        string ID { get; set; }
        string FirstName { get; set; }
        string MidName { get; set; }
        string LastName { get; set; }

        string JoiningBatch { get; set; }
        string DeptSub { get; set; }
        string DegreeChoise { get; set; }
        //public List<SemesterAdd> SemisterAdds { get; set; }
        
    }
}
