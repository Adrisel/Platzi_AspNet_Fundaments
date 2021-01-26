using System;
using Stage1.Entities;
using Stage1.App;
using Stage1.Util;

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
            engine.PrintDictionary(dictionaryResult, true);
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
