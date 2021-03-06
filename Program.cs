﻿using System;
using Stage1.Entities;
using Stage1.App;
using Stage1.Util;
using Stage1.Entities.EventArgsModels;
using System.Dynamic;

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
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);

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

            //reporter
            Reporter reporter = new Reporter(dictionaryResult);
            var testReport = reporter.GetListTest();
            var subjectReport = reporter.GetListSubject();
            var testBySubject = reporter.GetTestsBySubject();
            var test = reporter.GetStudentAverageBySubject();
            var top = reporter.GetTopScoresBySubject(4);


            //To see exceptions
            var newTest = new Test();
            string name, scoreString;

            Console.WriteLine("Enter a name test");
            System.Console.WriteLine("Press enter to continue after to write a name");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name cant be empty or spaces");
            }
            else
            {
                newTest.Name = name;
                System.Console.WriteLine("The test name was added correctly");
            }

            Console.WriteLine("Enter a score test");
            System.Console.WriteLine("Press enter to continue after to write a name");
            scoreString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(scoreString))
            {
                System.Console.WriteLine("The score cant be empty");
            }
            else
            {
                try
                {
                    newTest.Score = float.Parse(scoreString);
                    if (newTest.Score < 0 || newTest.Score > 5)
                    {
                        throw new ArgumentOutOfRangeException("The score cant be less than zero or more than 5");
                    }
                    System.Console.WriteLine("The test name was added correctly");
                }
                catch(ArgumentOutOfRangeException arg)
                {
                    System.Console.WriteLine(arg.Message);
                }
                catch (Exception)
                {
                    System.Console.WriteLine("The score value is not a number");
                }
            }

        }

        // This is what will happen when the publisher notifies when a course is added
        private static void AddCourseEventAction(object source, CourseEventArgs args)
        {
            Printer.PrintTitle($"A new Course was added to the School \nCourse: {args.Name} \nAddress: {args.Address}");
        }

        private static void NewStudentAdded(object sender, EventArgs e)
        {
            Printer.PrintTitle("There is a new student in the school");
        }

        private static void EventAction(object sender, EventArgs e)
        {
            Printer.PrintTitle("Finishing");
            Printer.Beep(3000, 1000, 3);
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
