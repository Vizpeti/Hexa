using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hexa
{
    public class Sound
    {
        private static char[] LongVowels = new[] { 'á', 'é', 'í', 'ó', 'ő', 'ú', 'ű' };
        private static char[] ShortVowels = new[] { 'a', 'e', 'i', 'o', 'ö', 'u', 'ü' };
        private static string[] DoubleletterSounds = new[] { "cs", "dz", "gy", "ly", "ny", "sz", "ty", "zs" };
        private static string[] TripleletterSounds = new[] { "dzs" };

        private string _letters;

        public Sound(string letters)
        {
            letters = letters.ToLower();

            if (!IsSound(letters))
                throw new ArgumentException("Not a valid sound", nameof(letters));

            _letters = letters;
        }

        private static bool IsSound(string letters)
        {
            if (TripleletterSounds.Contains(letters))
                return true;
            if (DoubleletterSounds.Contains(letters))
                return true;
            if (letters.Length == 1)
                return true;
            return false;
        }

        public static IEnumerable<Sound> ToSounds(string letters)
        {
            letters = letters.ToLower();

            var index = 0;
            while (index < letters.Length)
            {
                var threeLetterSound = GetThreeletterSound(letters, index);
                var twoLetterSound = GetTwoletterSound(letters, index);
                var oneLetterSound = GetOneletterSound(letters, index);

                if (threeLetterSound != null)
                {
                    yield return threeLetterSound;
                    index = index + 3;
                }
                else if (twoLetterSound != null)
                {
                    yield return twoLetterSound;
                    index = index + 2;
                }
                else if (oneLetterSound != null)
                {
                    yield return oneLetterSound;
                    index++;
                }
                else
                    throw new ArgumentException("Cannot be resolved to sounds!", nameof(letters));
            }
        }

        private static Sound GetThreeletterSound(string letters, int index)
        {
            if (index + 2 >= letters.Length)
                return null;
            var threeLetters = letters.Substring(index, 3);
            return IsSound(threeLetters)
                ? new Sound(threeLetters)
                : null;
        }

        private static Sound GetTwoletterSound(string letters, int index)
        {
            if (index + 1 >= letters.Length)
                return null;
            var twoLetters = letters.Substring(index, 2);
            return IsSound(twoLetters)
                ? new Sound(twoLetters)
                : null;
        }

        private static Sound GetOneletterSound(string letters, int index)
        {
            var oneLetter = letters.Substring(index, 1);
            return IsSound(oneLetter)
                ? new Sound(oneLetter)
                : null;
        }

        public override bool Equals(object obj)
        {
            return obj != null && ((Sound)obj)._letters == _letters;
        }

        public override string ToString()
        {
            return $"Hang:{_letters}";
        }

        public bool IsConsonant()
        {
            return !IsVowel();
        }

        public bool IsVowel()
        {
            return LongVowels.Contains(_letters[0]) || ShortVowels.Contains(_letters[0]);
        }

        public bool IsShortVowel()
        {
            return ShortVowels.Contains(_letters[0]);
        }
    }
}
