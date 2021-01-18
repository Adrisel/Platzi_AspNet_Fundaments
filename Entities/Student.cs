using System;
using System.Collections.Generic;

namespace Stage1.Entities
{
    
    public class Student
    {
        public string Name { get; set; }
        public string  Id { get; private set; }
        public List<Test> Tests { get; set; }

        public Student()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}