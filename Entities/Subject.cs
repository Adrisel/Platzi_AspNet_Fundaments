using System;

namespace Stage1.Entities
{
    
    public class Subject
    {
        public string Name { get; set; }
        public string  Id { get; private set; }

        public Subject()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}