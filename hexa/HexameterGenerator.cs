using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hexa
{
    public class HexameterGenerator
    {
        private Dictionary<string, SyllableList> _wordToSyllableMap;

        public HexameterGenerator(IEnumerable<string> words)
        {
            _wordToSyllableMap = new Dictionary<string, SyllableList>();
            foreach(var word in words.Distinct())
            {
                _wordToSyllableMap.Add(word,new SyllableList(Syllabler.ToSyllables(word)));
            }
        }

        public IDictionary<string, SyllableList> WordsAndSyllables => _wordToSyllableMap;


    }
}
