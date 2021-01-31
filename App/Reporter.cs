using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Stage1.Entities;
using Stage1.Entities.Constats;

namespace Stage1.App
{
    public class Reporter
    {
        Dictionary<DictionaryKey, IEnumerable<BaseSchool>> _dictionary;
        public Reporter(Dictionary<DictionaryKey, IEnumerable<BaseSchool>> dictionary)
        {
            _dictionary = dictionary;
        }

        public IEnumerable<Test> GetListTest()
        {
            if (_dictionary.TryGetValue(DictionaryKey.Test, out IEnumerable<BaseSchool> TestsList))
            {
                return TestsList.Cast<Test>();
            }
            else
            {
                return new List<Test>();
            }
        }

        public IEnumerable<string> GetListSubject()
        {
           return  GetListSubject(out var dummy);
        }

        public IEnumerable<string> GetListSubject(out IEnumerable<Test> testList)
        {
           testList = GetListTest();

           return (from test in testList
                  select test.Subject.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<Test>> GetTestsBySubject()
        {
            var dictionary = new  Dictionary<string, IEnumerable<Test>>();
            var subjectsList = GetListSubject(out IEnumerable<Test> testsList);

            foreach (var subject in subjectsList)
            {
                var testListBySubject = from test in testsList
                                        where test.Subject.Name == subject
                                        select test;
                dictionary.Add(subject, testListBySubject);
            }
            return dictionary;
        }

        public Dictionary<string, IEnumerable<StudentAverange>> GetStudentAverageBySubject()
        {
            var studentAverageBySubjectDictionary =  new Dictionary<string, IEnumerable<StudentAverange>>();
            var testDictionaryBySubject = GetTestsBySubject();

            foreach (var evalBySubject in testDictionaryBySubject)
            {
                var studentAverange = from eval in evalBySubject.Value
                            group eval by new {eval.Student.Id, eval.Student.Name}
                            into evalStudentGroup
                            select new StudentAverange
                            { 
                                StudentId = evalStudentGroup.Key.Id,
                                StudentName = evalStudentGroup.Key.Name,
                                Average = evalStudentGroup.Average(x => x.Score)
                            };

                studentAverageBySubjectDictionary.Add(evalBySubject.Key, studentAverange);
            }

            return studentAverageBySubjectDictionary;
        }

        public Dictionary<string, IEnumerable<StudentAverange>> GetTopScoresBySubject(int numberOfTop = 1)
        {
            var topScoresList = new Dictionary<string, IEnumerable<StudentAverange>>();
            var testBySubjectAndStudent = GetStudentAverageBySubject();
            foreach (var evalBySubject in testBySubjectAndStudent)
            {
                var orderedList = (from eval in evalBySubject.Value
                                  orderby eval.Average descending
                                  select eval).Take(numberOfTop);
                topScoresList.Add(evalBySubject.Key,orderedList);
            }
            return topScoresList;
        }
    }
}