using System;

namespace ContentConsole
{
    public static class Program
    {
        static string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        public static void Main(string[] args)
        {
            Story1();
            Story2();
            Story3();
            Story4();

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        private static void Story1()
        {
            var parser = new BannedWordsParser();
            parser.LoadBannedWords("BannedWords.txt");
            parser.ParseAndFilter(content);

            Console.WriteLine("Scanned Text: {0}", content);
            Console.WriteLine("Total Number of negative words: {0}", parser.BannedWordsCounter);
        }

        private static void Story2()
        {
            //Update BannedWords File and rerun
            var parser = new BannedWordsParser();
            parser.LoadBannedWords("BannedWords.txt");
            parser.ParseAndFilter(content);

            Console.WriteLine("Scanned Text: {0}", content);
            Console.WriteLine("Total Number of negative words: {0}", parser.BannedWordsCounter);
        }

        private static void Story3()
        {
            var parser = new BannedWordsParser();
            parser.LoadBannedWords("BannedWords.txt");
            var filteredOutput = parser.ParseAndFilter(content, true);

            Console.WriteLine("Scanned Text: {0}", content);
            Console.WriteLine("Total Number of negative words: {0}", parser.BannedWordsCounter);
            Console.WriteLine("FilteredOutText: {0}", filteredOutput);
        }

        private static void Story4()
        {
            var parser = new BannedWordsParser();
            parser.LoadBannedWords("BannedWords.txt");
            var filteredOutput = parser.ParseAndFilter(content, false);

            Console.WriteLine("Scanned Text: {0}", content);
            Console.WriteLine("Total Number of negative words: {0}", parser.BannedWordsCounter);
        }

    }

}
