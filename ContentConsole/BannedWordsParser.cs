using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContentConsole
{
    public class BannedWordsParser
    {
        private List<BannedWord> _BannedWords;
        public BannedWordsParser()
        {
            _BannedWords = new List<BannedWord>();
        }

        public int BannedWordsCounter { get; set; }
        
        public void LoadBannedWords(string fileName)
        {
            var bannedWordList = File.ReadAllLines(fileName);
            foreach (var bannedWord in bannedWordList)
            {
                _BannedWords.Add(new BannedWord(bannedWord));
            }
        }

        public string ParseAndFilter(string text, bool filterBannedWords = false)
        {
            var outputBuilder = new StringBuilder();
            var words = text.Split(new char[] { ' ' });
            foreach (var word in words)
            {
                var tempWord = string.Empty;
                foreach (var bannedWord in _BannedWords)
                {
                    if (!word.Contains(bannedWord.ToString()))
                    {
                        tempWord = word;
                        continue;
                    }

                    tempWord = filterBannedWords ? word.Replace(bannedWord.Word, bannedWord.HashedWord) : word;
                    BannedWordsCounter++;
                    break;
                }

                outputBuilder.Append(tempWord).Append(' ');
            }

            return outputBuilder.ToString().TrimEnd();
        }
    }
}
