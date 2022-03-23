using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wordle
{
    public class NamesData 
    {
        public HashSet<char> lettersNotInWord = new();
        public HashSet<char> lettersInWordDiferentPlace = new();
        public char[] guesedletters = {'_','_','_','_','_'};

        public string nameToGuess { get; set;}
        static string words = File.ReadAllText("C:\\repositories\\TestModule\\Wordle\\Wordle\\letters5.txt");
        public List<string> wordsList = words.Split('\n').ToList();
    }
}
