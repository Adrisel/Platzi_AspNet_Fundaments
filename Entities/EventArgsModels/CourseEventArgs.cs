using System;

namespace Stage1.Entities.EventArgsModels
{
    public class CourseEventArgs: EventArgs
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public TurnType Turn { get; set; }
    }
}