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
            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine($"{course1.Name}, {course1.Id}");
            System.Console.WriteLine($"{course2.Name}, {course2.Id}");
        }
    }
}
