using System;
using Stage1.Entities;
using Stage1.App;
using Stage1.Util;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            Printer.PrintTitle("WELCOME TO THE SCHOOL");
            ShowSchoolCourses(engine.School);
            Printer.Beep();
            var dictionaryResult = engine.GetObjectDictionary();
            engine.PrintDictionary(dictionaryResult);
        }

        private static void ShowSchoolCourses(School mySchool)
        {
            Printer.PrintTitle("School Courses");
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
