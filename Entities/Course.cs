using System;
using System.Collections.Generic;
using Stage1.Entities.Interfaces;

namespace Stage1.Entities
{
    
    public class Course : BaseSchool, IPlace
    {
        public TurnType TurnType { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public string Address { get; set; }

        public void CleanPlace()
        {
            System.Console.WriteLine($"Course {Name} Cleaned");
        }
    }
}