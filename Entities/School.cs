namespace Stage1.Entities
{
    using System.Collections.Generic;
    using System;
    public class School : BaseSchool
    {
        public string Country { get; set; }
        public string City { get; set; }

        public SchoolType SchoolType { get; set; }
        public int YearFoundation { get; set; }

        public List<Course> Courses { get; set; }
        /// The properties are public because behind they set the value to a field, 
        //this is called encapsulation.

        public School(string name, int year)
        {
            Name = name;
            YearFoundation = year;
        }

        // Another way to set the values by the constructor is by tuples
        public School(string name) => (Name) = (name);

        public School(string name, SchoolType type, string country = "Bolivia", string city = "")
        {
            (Name, SchoolType) = (name, type);
            Country = country;
            City = city;            
        }

        //The ToString Method will be override

        public override string ToString()
        {
            return $"Name: {Name}, Level: {SchoolType} \nCountry: {Country}, City: {City}";
        }


    }

}