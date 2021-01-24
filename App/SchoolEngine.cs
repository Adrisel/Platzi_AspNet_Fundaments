namespace Stage1.App
{
    using Stage1.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public sealed class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine()
        {
        }

        public void Init()
        {
            School = new School("Platzi Academy", SchoolType.Elementary, city: "La Paz");

            AddCourses();
            AddStudents();
            AddSubjects();
            AddTests();
            School.CleanPlace();
            List<BaseSchool> list = GetObjectsBaseSchool(
                out int numberCourses,
                out int numberSubjects,
                out int numberStudents,
                out int numberTest,
                tests: false,
                students: false);
            Console.WriteLine($"Courses: {numberCourses} Subjects: {numberSubjects}");
        }
        // If we want the same functionality but with different parameters we can overload the method
        // declare the same name method with different paramenters
        private List<BaseSchool> GetObjectsBaseSchool( 
            bool courses = true,
            bool subjects = true,
            bool students = true,
            bool tests = true
        )
        {
            return GetObjectsBaseSchool(
                out int dummy,
                out dummy,
                out dummy,
                out dummy,
                courses,
                subjects,
                students,
                tests);
        }

        private List<BaseSchool> GetObjectsBaseSchool(
            out int numberOfCourses,
            bool courses = true,
            bool subjects = true,
            bool students = true,
            bool tests = true
        )
        {
            return GetObjectsBaseSchool(
                out numberOfCourses,
                out int dummy,
                out dummy,
                out dummy,
                courses,
                subjects,
                students,
                tests);
        }

        private List<BaseSchool> GetObjectsBaseSchool(
            out int numberOfCourses,
            out int numberOfSubjects,
            out int numberOfStudents,
            out int numberOfTests,
            bool courses = true,
            bool subjects = true,
            bool students = true,
            bool tests = true
        )
        {
            numberOfCourses = numberOfStudents = numberOfSubjects = numberOfTests = 0;
            List<BaseSchool> objectsSchoolList = new List<BaseSchool>();
            objectsSchoolList.Add(School);
            if (courses)
            {
                objectsSchoolList.AddRange(School.Courses);
                numberOfCourses = School.Courses.Count;
            }
            foreach (var course in School.Courses)
            {
                if (subjects)
                {
                    objectsSchoolList.AddRange(course.Subjects);
                    numberOfSubjects += course.Subjects.Count;
                }
                if (students)
                {
                    objectsSchoolList.AddRange(course.Students);
                    numberOfStudents += course.Students.Count;
                }
                if (tests)
                {
                    foreach (var student in course.Students)
                    {
                        objectsSchoolList.AddRange(student.Tests);
                        numberOfTests += student.Tests.Count;
                    }
                }
            }
            return objectsSchoolList;
        }
        #region Generate
        private List<Student> GenerateStudents(int quantity)
        {
            string[] name1 = new string[] { "Adriana", "Marcia", "Ronald", "Mauricio", "Daniel" };
            string[] name2 = new string[] { "Tito", "Camacho", "Sanchez", "Salazar", "Orellana" };

            var studentsList = from n1 in name1
                               from n2 in name2
                               select new Student() { Name = $"{n1} {n2}" };
            return studentsList.OrderBy(std => std.Id).Take(quantity).ToList();
        }
        private void GenerateTest(List<Subject> subjects, List<Student> students, string courseName)
        {
            Random random = new Random();
            foreach (var student in students)
            {
                List<Test> testList = new List<Test>();
                foreach (var subject in subjects)
                {
                    float score = (float)(5 * random.NextDouble());
                    string studentName = student.Name;
                    string testName = $"{subject.Name} - {courseName}";
                    testList.Add(new Test()
                    {
                        Name = testName,
                        Score = score,
                        Student = student,
                        Subject = subject
                    });
                }
                student.Tests = testList;
            }
        }
        #endregion

        #region Add to School
        private void AddTests()
        {
            foreach (var course in School.Courses)
            {
                GenerateTest(course.Subjects, course.Students, course.Name);
            }
        }
        private void AddSubjects()
        {
            foreach (var course in School.Courses)
            {
                List<Subject> subjectList = new List<Subject>()
                {
                    new Subject(){Name = "Maths"},
                    new Subject(){Name = "Spanish"},
                    new Subject(){Name = "Science"},
                    new Subject(){Name = "Sports"},

                };
                course.Subjects = subjectList;
            }
        }

        private void AddStudents()
        {
            Random random = new Random();
            foreach (var course in School.Courses)
            {
                int numeberOfStudent = random.Next(5, 20);
                course.Students = GenerateStudents(numeberOfStudent);
            }
        }

        private void AddCourses()
        {
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
    #endregion
}