using Newtonsoft.Json;
using Student_Management_System_SMS_;
using System.Drawing;
using System.Runtime.CompilerServices;

class Program
{
    static Dictionary<int, Student> listDic = new Dictionary<int, Student>();
    private static string StudentsFilePath = "students.json";


    static List<Course> HardCourse = new List<Course>
         {
            new Course { CourseID = "CSE 101", CourseName = "Introduction to Computer Science", InstructorName = "Prof.Jamal", NumberOfCradit = 3.5},
            new Course { CourseID = "CSE 102", CourseName = "Discreate Mathematics", InstructorName = "Prof.Kamal", NumberOfCradit = 2.5},
            new Course { CourseID = "CM 103", CourseName = "Computer Mathematics", InstructorName = "Prof.Kamal", NumberOfCradit = 2.5},
            new Course { CourseID = "CSE 202", CourseName = "Compiler", InstructorName = "Prof.khan", NumberOfCradit = 2.5},
            new Course { CourseID = "CSE 203", CourseName = "Microprocessor", InstructorName = "Prof.khanl", NumberOfCradit = 3.5}
         };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n\n** Welcome to the Student Management System **\n");
            Console.WriteLine("1. Insert new Student  ");
            Console.WriteLine("2. View ALL Student");
            Console.WriteLine("3. Search Specific Student with Student ID");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Add Semester for Student");
            Console.WriteLine("6. Exit");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Your choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertStudent();
                    break;
                case 2:
                    ViewStudent();
                    break;
                case 3:
                    Console.Write("Enter Search SID : ");
                    int sid = int.Parse(Console.ReadLine());
                    SearchStudent(sid);
                    break;
                case 4:
                    DeleteStudent();
                    break;
                case 5:
                    AddSemester();
                    break;
                case 6:
                    return;

            }
        }
    }

    static void InsertStudent()
    {
        Console.Clear();
        Student student = new Student();
        bool found = false;
        while(!found)
        {
            Console.Write("Enter student ID : ");
            student.ID = Console.ReadLine();
            string str = student.ID;
            if(string.IsNullOrEmpty(str) == false)
            {
                found = true;
            }
            else
            {
                Console.WriteLine("\nPlease inter a valid integer number as ID.\n");
            }
        }
        
        Console.Write("Enter student FirstName : ");
        student.FirstName = Console.ReadLine();
        Console.Write("Enter student MidName : ");
        student.MidName = Console.ReadLine();
        Console.Write("Enter student LastName : ");
        student.LastName = Console.ReadLine();
        Console.Write("Enter student JoiningBatch : ");
        student.JoiningBatch = Console.ReadLine();
        found = false;
        while (!found)                                                                     // For valid Department Name
        {
            Console.Write("Enter Valid Department (ComputerScience, BBA, English) : ");
            student.DeptSub = Console.ReadLine();

            foreach (string str in Enum.GetNames(typeof(deptName)))
            {
                if (str == student.DeptSub)
                {
                    found = true; break;
                }
            }
            if (!found) Console.WriteLine("\nPlease enter a valid Dept. Name!\n");
        }

        found = false;
        while (!found)                                           // For valid Degree Name
        {
            Console.Write("Enter Valid Degree ( BSC, BBA, BA, MSC, MBA, MA) : ");
            student.DegreeChoise = Console.ReadLine();

            foreach (string str in Enum.GetNames(typeof(degreeName)))
            {
                if (str == student.DegreeChoise)
                {
                    found = true; break;
                }
            }
            if (!found) Console.WriteLine("\nPlease enter a valid Degree Name!\n");
        }


        int sid = int.Parse(student.ID);
        listDic.Add(sid, student);
        SaveStudentToJson(listDic);
        Console.WriteLine();
        Console.WriteLine("***Student Successfully Entered.***");
        
    }
    private static void ViewStudent()
    {
        var str = LoadStudents();
        if (str.Count == 0)
        {
            Console.WriteLine("\n***NO Record to be viewed :(***\n");
            return;
        }
        int cnt = 1;
        foreach (int sid in str.Keys)
        {
            Console.WriteLine($"***** Student {cnt++} *****");
            SearchStudent(sid);
        }
        
    }

    static void SearchStudent(int sid)
    {
        Console.Clear();
        var str = LoadStudents();
        if (str.ContainsKey(sid) == true)
        {
                Student student = str[sid];
                Console.WriteLine($"\nID : {student.ID}");
                Console.WriteLine($"FirstName : {student.FirstName}");
                Console.WriteLine($"MidName : {student.MidName}");
                Console.WriteLine($"LastName : {student.LastName}");
                Console.WriteLine($"JoiningBatch : {student.JoiningBatch}");
                Console.WriteLine($"Department : {student.DeptSub}");
                Console.WriteLine($"DegreeChoise  : {student.DegreeChoise}");
            
               
               foreach(var semes in student.DiffSemester)
               {
                Console.WriteLine($"\nSemester Code & Year: {semes.SemisterCode}   {semes.Year}");
                    foreach(var course in semes.courses)
                    {
                        Console.Write($"{course.CourseID}  {course.CourseName}  {course.InstructorName}  {course.NumberOfCradit}");
                        Console.WriteLine();
                    }
               }

        }
        else
        {
            Console.WriteLine("\n **No Student found.**\n");
        }
        
    }
    private static void DeleteStudent()
    {
        Console.Clear();
        Console.Write("\nEnter Search SID : ");
        int sid = int.Parse(Console.ReadLine());
        
        if (listDic.ContainsKey(sid) == true)
        {
            listDic.Remove(sid);
            Console.WriteLine($"\n***Successfully Removed Student Contain ID {sid}.***\n");
        }
        else 
        {
            Console.WriteLine("\n**No Student found.**\n");
        }
        
    }

    private static void AddSemester()
    {
        Console.Write("\nEnter Search SID : ");
        int sid = int.Parse(Console.ReadLine());
                
        if (listDic.ContainsKey(sid) == true)
        {
            var student = listDic[sid];
            var semester = new SemesterAdd();

            bool found = false;
            while (!found)  // For valid Semester
            {
                Console.Write("\nEnter Valid Semester Code (Summer, Fall, Spring) : ");
                semester.SemisterCode = Console.ReadLine()!;

                foreach (string str in Enum.GetNames(typeof(semesterCode)))
                {
                    if (str == semester.SemisterCode)
                    {
                        found = true; break;
                    }
                }
                if (!found) Console.WriteLine("\nPlease enter a valid Semester!!\n");
            }
            
            Console.Write("\nEnter Year : ");
            semester.Year = Console.ReadLine();
            var coursesNotTaken = HardCourse.Where(course => !student.DiffSemester.Any(semes => semes.courses.Any(sub => sub.CourseID == course.CourseID))).ToList();
            
            Console.Write("\n*** Courses That You Have Not Taken Yet In Any Semester :)\n");
            int cnt = 1;
            foreach(var course in coursesNotTaken)
            {
                Console.WriteLine($"{cnt++}. Course ID: {course.CourseID}, Course Name : {course.CourseName}");               
            }
            found = false;
            while(!found)       // For Valid Course ID
            {
                Console.Write("\nEnter Valid Course ID to add : ");
                var newCourseID = Console.ReadLine();


                foreach (var course in coursesNotTaken)
                {
                    if (course.CourseID == newCourseID)
                    {
                        semester.courses.Add(course);
                        found = true;
                        Console.WriteLine($"\n***Course {newCourseID} Successfully Added.***\n");
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"\n*** {newCourseID} is not valid course to add.***\n");
                }
            }

            var isSemesterExists = student.DiffSemester.Exists(s => s.SemisterCode == semester.SemisterCode && s.Year == semester.Year);
            if(isSemesterExists)
            {
                var existingSemester = student.DiffSemester.Single(s => s.SemisterCode == semester.SemisterCode && s.Year == semester.Year);
                existingSemester.courses.AddRange(semester.courses);

                return;
            }
            
            student.DiffSemester.Add(semester);
            Console.WriteLine($"{semester.SemisterCode} Semester Added Successfully.\n");
        }
        else
        {
            Console.WriteLine("\nStudent not found.\n");
        }
    }


    public static Dictionary<int, Student>? LoadStudents()
    {
        if (File.Exists(StudentsFilePath))
        {
            string json = File.ReadAllText(StudentsFilePath);
            return JsonConvert.DeserializeObject<Dictionary<int, Student>>(json);
        }
        return new Dictionary<int, Student>();
    }
 

   /* public static Dictionary<int, Student> LoadStudentFromJson()
    {
        try
        {
            string json = File.ReadAllText("../../../students.json");
            students = JsonConvert.DeserializeObject<Dictionary<int, Student>>(json); 
        }
        catch (FileNotFoundException)
        {
            File.WriteAllText("../../../students.json", "[]");
        }
    }*/

    public static void SaveStudentToJson(Dictionary<int, Student> students)
    {
        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(StudentsFilePath, json);
    }
}