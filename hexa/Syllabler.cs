using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hexa
{
    public class Syllabler
    {
        
        public static IEnumerable<Syllable> ToSyllables(string word)
        {
            var sounds = Sound.ToSounds(word).ToArray();
            
            for (var i = 0; i < sounds.Length; i++)
            {
                var sound = sounds[i];

                if (sound.IsVowel())
                {
                    yield return IsShortSyllable(sounds, i)
                        ? Syllable.Short
                        : Syllable.Long;
                }
            }
        }

        private static bool IsShortSyllable(Sound[] sounds, int index)
        {
            return sounds[index].IsShortVowel() && GetNumberOfConsonantsFollowing(sounds, index) <2;
        }

        private static int GetNumberOfConsonantsFollowing(Sound[] sounds, int index)
        {
            int counter = 0;
            while (index+1 < sounds.Length && sounds[index + 1].IsConsonant())
            {
                counter++;
                index++;
            }
            return counter;
        }
    }
}
