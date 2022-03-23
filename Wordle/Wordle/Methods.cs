using System;
using System.Collections.Generic;
using System.Linq;

namespace Wordle
{
    public class Methods : NamesData
    {
        public void GetUnknownWord()
        {
            Random random = new();
            int randomInt = random.Next(0, wordsList.Count);
            nameToGuess = wordsList[randomInt];
        }

        public bool GuessNameValid(string word)
        {
            return wordsList.Contains(word.ToLower());
        }

        public bool GuessCheck(string word)
        {
            return word == nameToGuess;
        }

        public void GetResponse(string word)
        {
            List<char> lettersGuessword = word.ToCharArray().ToList();

            List<char> notInGuessWord = (from c in lettersGuessword
                                               where !nameToGuess.Contains(c)
                                               select c).ToList();
            List<char> isInGuessWord = (from c in lettersGuessword
                where nameToGuess.Contains(c)
                select c).ToList();

            foreach (var c in notInGuessWord)
            {
                lettersNotInWord.Add(c);
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (isInGuessWord.Contains(word[i]) & nameToGuess[i] != word[i])
                {
                    lettersInWordDiferentPlace.Add(word[i]);
                }
                else if (isInGuessWord.Contains(word[i]) & nameToGuess[i] == word[i])
                {
                    guesedletters[i] = word[i];
                }
            }
        }
    }
}
