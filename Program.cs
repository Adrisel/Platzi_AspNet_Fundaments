using System;
using Stage1.Entities;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            School mySchool = new School("Platzi Academy", SchoolType.Elementary, city: "La Paz");
            System.Console.WriteLine(Convert.ToString(mySchool));

            /// instance 3 courses

            Course course1 = new Course()
            {
                Name = "101",
                TurnType = TurnType.Morning
            };

            Course course2 = new Course()
            {
                Name = "201",
                TurnType = TurnType.Morning
            };

            Course course3 = new Course()
            {
                Name = "201",
                TurnType = TurnType.Morning
            };

            //Create an array of curses

            var arrayCourses = new Course[3];
            arrayCourses[0] = course1;
            arrayCourses[1] = course2;
            arrayCourses[2] = course3;

            ShowCourses(arrayCourses); 
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
    }
}
