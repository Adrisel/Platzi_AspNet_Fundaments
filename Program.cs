using System;
using Stage1.Entities;
using System.Collections.Generic;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            School mySchool = new School("Platzi Academy", SchoolType.Elementary, city: "La Paz");
            System.Console.WriteLine(Convert.ToString(mySchool));

            mySchool.Courses = new List<Course>
            {
               new Course(){ Name = "101",TurnType = TurnType.Morning},
               new Course(){ Name = "201",TurnType = TurnType.Morning},
               new Course(){ Name = "301",TurnType = TurnType.Morning}
            };
            // Adds a neew object to the list
            mySchool.Courses.Add( new Course(){Name = "102", TurnType=TurnType.Afternoon});

            // Adds a new collection to the collection 
            List<Course> secondCourse = new List<Course>()
            {
                new Course{Name = "401", TurnType=TurnType.Morning},
                new Course{Name = "501", TurnType=TurnType.Morning}
            };

            mySchool.Courses.AddRange(secondCourse);

            ShowSchoolCourses(mySchool);
        }

        private static void ShowSchoolCourses(School mySchool)
        {
            System.Console.WriteLine("School Courses-------------------");
            if(mySchool?.Courses != null)
            {
                foreach (var course in mySchool.Courses)
                {
                    System.Console.WriteLine($"Name {course.Name} ID {course.Id}");
                }
            }
        }

        private static void ShowCourses(Course[] arrayCourses)
        {
            int c = 0;
            while (c < arrayCourses.Length)
            {
                System.Console.WriteLine($"Name {arrayCourses[c].Name} ID {arrayCourses[c].Id}");
                c++;
            }
        }

        private static void ShowCoursesWithForeach(Course[] arrayCourses)
        {
            foreach (var course in arrayCourses)
            {
                System.Console.WriteLine($"Name {course.Name} ID {course.Id}");
            }
        }
    }
}
