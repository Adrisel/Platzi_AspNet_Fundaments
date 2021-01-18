using System;

namespace Stage1.Entities
{
    
    public class Test
    {
        public string Name { get;  set; }
        public string  Id { get; private set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Score { get; set; }
        public Test()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}