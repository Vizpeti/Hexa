using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hexa;
using System.Linq;
using System.Collections.Generic;

namespace UntiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringToSyllablesTest()
        {
            TestWord("a", new[] { Syllable.Short });
            TestWord("á", new[] { Syllable.Long });
            TestWord("al", new[] { Syllable.Short });
            TestWord("all", new[] { Syllable.Long });
            TestWord("állat", new[] { Syllable.Long, Syllable.Short });
            TestWord("al alak", "lss");
            TestWord("aalallalllááláll", "sslllll");
        }

        [TestMethod]
        public void StringToSyllablesDoubleletterTest()
        {
            TestWord("egy", "s");
        }

        [TestMethod]
        public void TestHexameterGeneratorInitialization()
        {
            var words = new[] { "a", "á", "laliazállat", "tallat" };

            var hexameterGenerator = new HexameterGenerator(words);
            foreach (var wordAndSyllables in hexameterGenerator.WordsAndSyllables)
                TestWord(wordAndSyllables.Key, wordAndSyllables.Value);
        }

        private static void TestWord(string word, IEnumerable<Syllable> expectedResult)
        {
            var expectedArray = expectedResult.ToArray();
            var x = Syllabler.ToSyllables(word).ToArray();

            Assert.AreEqual(expectedArray.Length, x.Length);
            for (var i = 0; i < expectedArray.Length; i++)
                Assert.AreEqual(expectedArray[i], x[i]);
        }

        private static void TestWord(string word, string syllableCode)
        {
            TestWord(word, new SyllableList(syllableCode));
        }

        [TestMethod]
        public void SoundTests()
        {
            new Sound("a");
            new Sound("gy");
            new Sound("dzs");
            new Sound("x");
            new Sound("y");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongSoundTest2()
        {
            new Sound("fy");
        }

        [TestMethod]
        public void ToSoundsTest1()
        {
            var sounds = Sound.ToSounds("egy").ToArray();
            Assert.AreEqual(2, sounds.Length);
            Assert.AreEqual(new Sound("e"), sounds[0]);
            Assert.AreEqual(new Sound("gy"), sounds[1]);
        }

        [TestMethod]
        public void ToSoundsTest2()
        {
            var sounds = Sound.ToSounds("Dzsudzsáktyúk").ToArray();
            Assert.AreEqual(8, sounds.Length);
            Assert.AreEqual(new Sound("dzs"), sounds[0]);
            Assert.AreEqual(new Sound("u"), sounds[1]);
            Assert.AreEqual(new Sound("dzs"), sounds[2]);
            Assert.AreEqual(new Sound("á"), sounds[3]);
            Assert.AreEqual(new Sound("k"), sounds[4]);
            Assert.AreEqual(new Sound("ty"), sounds[5]);
            Assert.AreEqual(new Sound("ú"), sounds[6]);
            Assert.AreEqual(new Sound("k"), sounds[7]);
        }
    }
}
