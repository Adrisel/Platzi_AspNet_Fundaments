namespace Stage1.App
{
    using Stage1.Entities;
    using System.Collections.Generic;
    public class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine()
        {

        }

        public void Init()
        {
            School = new School("Platzi Academy", SchoolType.Elementary, city: "La Paz");
            School.Courses = new List<Course>
            {
               new Course(){ Name = "101",TurnType = TurnType.Morning},
               new Course(){ Name = "201",TurnType = TurnType.Morning},
               new Course(){ Name = "301",TurnType = TurnType.Morning},
               new Course(){ Name = "401",TurnType = TurnType.Morning},
               new Course(){ Name = "501",TurnType = TurnType.Morning}
            };
        }
    }
}