using System;

namespace ContentConsole
{
    internal class BannedWord
    {
        public BannedWord(string word)
        {
            Word = word;
            HashedWord = GetHashword(word);
        }

        public string Word { get; private set; }
        public string HashedWord { get; private set; }

        private static string GetHashword(string word)
        {
            var charArray = new Char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                if (i == 0 || i == (word.Length - 1))
                {
                    charArray[i] = word[i];
                    continue;
                }

                charArray[i] = '#';
            }
            return new string(charArray);
        }

        public override string ToString()
        {
            return Word;
        }
    }
}
