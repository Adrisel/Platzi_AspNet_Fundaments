using System;
using System.Collections.Generic;

namespace Stage1.Entities
{
    
    public class Course : BaseSchool
    {
        public TurnType TurnType { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
    }
}