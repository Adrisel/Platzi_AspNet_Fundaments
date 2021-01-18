using System;
using System.Collections.Generic;

namespace Stage1.Entities
{
    
    public class Course
    {
        public string Name { get; set; }
        public string  Id { get; private set; }
        public TurnType TurnType { get; set; }
        public Subject Subject { get; set; }
        public List<Student> Students { get; set; }

        public Course()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}