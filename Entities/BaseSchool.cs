using System;
namespace Stage1.Entities
{
    public abstract class BaseSchool
    {
        public string Name { get; set; }
        public string  Id { get; private set; }
        public BaseSchool()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}