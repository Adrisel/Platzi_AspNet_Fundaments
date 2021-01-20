using System;

namespace Stage1.Entities
{
    
    public class Test :BaseSchool
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Score { get; set; }

        public override string ToString()
        {
            return $"{Subject.Name}, {Student.Name}, {Score}";
        }
    }
}