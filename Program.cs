using System;
using Stage1.Entities;
using Stage1.App;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            ShowSchoolCourses(engine.School);
            
        }

        private static void ShowSchoolCourses(School mySchool)
        {
            System.Console.WriteLine("School Courses-------------------");
            if (mySchool?.Courses != null)
            {
                foreach (var course in mySchool.Courses)
                {
                    System.Console.WriteLine($"Name {course.Name} ID {course.Id}");
                }
            }
        }
    }
}
