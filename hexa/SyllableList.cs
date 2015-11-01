using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hexa
{
    public class SyllableList : List<Syllable>
    {
        public SyllableList(IEnumerable<Syllable> syllables)
            : base(syllables)
        {
        }

        public SyllableList(string syllableCodes)
            : base(syllableCodes.Select(i => ToSyllable(i)))
        {
        }

        private static Syllable ToSyllable(char i)
        {
            i = i.ToString().ToUpper()[0];
            if (i != 'S' && i != 'L')
                throw new Exception("Must be S or L!");

            return i == 'S' ? Syllable.Short : Syllable.Long;
        }

        public override string ToString()
        {
            return new string(this.Select(i => i == Syllable.Short ? 'S' : 'L').ToArray());
        }
    }
}
