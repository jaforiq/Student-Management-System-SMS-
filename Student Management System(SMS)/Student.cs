using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_SMS_
{
    public class Student : IStudent
    {
        string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        string midName;
        public string MidName
        {
            get { return midName; }
            set { midName = value; }
        }
        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        string joiningBatch;
        public string JoiningBatch
        {
            get { return joiningBatch; }
            set { joiningBatch = value; }                                                                                   
        }
        string dept;
        public string DeptSub
        {
            get { return dept; }
            set { dept = value; }
        }
        string degreechoise;
        public string DegreeChoise
        {
            get { return degreechoise; }
            set { degreechoise = value; }
        }
        public List<SemesterAdd> DiffSemester = new List<SemesterAdd>();

        public SemesterAdd Semesters;

    }
}
