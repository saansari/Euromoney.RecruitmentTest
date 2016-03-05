using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    public class ParserTests
    {
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2)]
        public void TestBannedWords(string content, int result)
        {
            var parser = new BannedWordsParser();
            parser.LoadBannedWords("BannedWords.txt");
            parser.ParseAndFilter(content);

            Assert.That(parser.BannedWordsCounter == result);
        }

        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", "#")]
        public void TestHashedWords(string content, string filterCharacter)
        {
            var parser = new BannedWordsParser();
            parser.LoadBannedWords("BannedWords.txt");
            var output = parser.ParseAndFilter(content, true);

            Assert.That(output.Contains(filterCharacter));
        }
    }
}
