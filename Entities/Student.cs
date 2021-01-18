using System;

namespace Stage1.Entities
{
    
    public class Student
    {
        public string Name { get; private set; }
        public string  Id { get; private set; }

        public Student()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}