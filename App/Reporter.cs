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

        public IEnumerable<School> GetListTest()
        {
            IEnumerable<School> list;
            if (_dictionary.TryGetValue(DictionaryKey.School, out IEnumerable<BaseSchool> School))
            {
                list = School.Cast<School>();
            }
            else
            {
                list = null;
            }

            return list;
        }
    }
}