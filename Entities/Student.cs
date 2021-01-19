using System;
using System.Collections.Generic;

namespace Stage1.Entities
{
    
    public class Student : BaseSchool
    {
        public List<Test> Tests { get; set; }
    }
}