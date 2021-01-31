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
            return GetListSubject(out var dummy);
        }

        public IEnumerable<string> GetListSubject(out IEnumerable<Test> testList)
        {
            testList = GetListTest();

            return testList.Select(x => x.Subject.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<Test>> GetTestsBySubject()
        {
            var dictionary = new Dictionary<string, IEnumerable<Test>>();
            var subjectsList = GetListSubject(out IEnumerable<Test> testsList);

            foreach (var subject in subjectsList)
            {
                var testListBySubject = testsList.Where(x => x.Subject.Name == subject);
                dictionary.Add(subject, testListBySubject);
            }
            return dictionary;
        }

        public Dictionary<string, IEnumerable<StudentAverange>> GetStudentAverageBySubject()
        {
            var studentAverageBySubjectDictionary = new Dictionary<string, IEnumerable<StudentAverange>>();
            var testDictionaryBySubject = GetTestsBySubject();

            foreach (var evalBySubject in testDictionaryBySubject)
            {

                var studentA = evalBySubject.Value.GroupBy(x => x.Student.Name);
                List<StudentAverange> studentAverange = new List<StudentAverange>();
                foreach (var studentScore in studentA)
                {
                    float average = studentScore.Average(x => x.Score);
                    string id = studentScore.First().Student.Id;
                    studentAverange.Add(new StudentAverange
                    {
                        StudentId = id,
                        StudentName = studentScore.Key,
                        Average = average
                    });
                }
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
                var orderedList = evalBySubject.Value.OrderByDescending(x => x.Average)
                                                     .Take(numberOfTop);
                topScoresList.Add(evalBySubject.Key, orderedList);
            }
            return topScoresList;
        }
    }
}