using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hexa
{
    class Program
    {
        static List<string> _wordlist;

        static void Main(string[] args)
        {
            _wordlist = new List<string>();

            FillWordList(_wordlist);

            var x = new HexameterGenerator(_wordlist);

        }

        private static void FillWordList(List<string> wordlist)
        {
            using (var reader = new StreamReader(@"C:\Users\Petya\Desktop\PROJEKT HEXAMETER\words.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    wordlist.Add(line);

                }
            }
        }
    }
}
