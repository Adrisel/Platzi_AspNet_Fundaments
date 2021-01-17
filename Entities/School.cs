namespace Stage1.Entities
{
    using System.Collections.Generic;
    class School
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Country { get; set; }
        public string City { get; set; }

        public SchoolType SchoolType { get; set; }
        public int YearFoundation { get; set; }

        public List<Course> Courses { get; set; }
        /// The properties are public because behind they set the value to a field, 
        //this is called encapsulation.

        public School(string name, int year)
        {
            this.name = name;
            YearFoundation = year;
        }

        // Another way to set the values by the constructor is by tuples
        public School(string name) => (this.name) = (name);

        public School(string name, SchoolType type, string country = "Bolivia", string city = "")
        {
            (this.name, SchoolType) = (name, type);
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