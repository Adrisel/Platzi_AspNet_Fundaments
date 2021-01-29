using System;
using Stage1.Entities;
using Stage1.App;
using Stage1.Util;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            //here we are subscribing to the ProcessExit Event
            AppDomain.CurrentDomain.ProcessExit += EventAction;
            ///This is another way to subscribe to an Event using lambda function 
            // Both of the delegates will be executed because a Eventcan acumulate more than one delegates
            AppDomain.CurrentDomain.ProcessExit += (o,s) => Printer.Beep(2000,1000,1);

            // If you want to unsubscribe to an event 
            AppDomain.CurrentDomain.ProcessExit -= EventAction;

            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            Printer.PrintTitle("WELCOME TO THE SCHOOL");
            ShowSchoolCourses(engine.School);
            Printer.Beep();
            var dictionaryResult = engine.GetObjectDictionary();
            // engine.PrintDictionary(dictionaryResult, true);

            // here we are subscribing to the event when a new course is added
            engine.AddCourseProcess += AddCourseEventAction;
            engine.AddCourse("601", "Cochabamba", TurnType.Morning);

        }

        // This is what will happen when the publisher notifies when a course is added
        private static void AddCourseEventAction(object source, EventArgs args)
        {
            Printer.PrintTitle("A new Course was added to the School");
        }

        private static void NewStudentAdded(object sender, EventArgs e)
        {
            Printer.PrintTitle("There is a new student in the school");
        }

        private static void EventAction(object sender, EventArgs e)
        {
            Printer.PrintTitle("Finishing");
            Printer.Beep(3000,1000,3);
            Printer.PrintTitle("Finished");
        }

        private static void ShowSchoolCourses(School mySchool)
        {
            Printer.PrintTitle("School Courses");
            if (mySchool?.Courses != null)
            {
                foreach (var course in mySchool.Courses)
                {
                    System.Console.WriteLine($"Name {course.Name} ID {course.Id}");
                }
            }
        }
    }
}
