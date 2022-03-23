using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wordle.Tests
{
    [TestClass]
    public class WordleV2Tests
    {
        public Methods game;

        [TestInitialize]
        public void Setup()
        {
            game = new Methods();
            game.GetUnknownWord();
        }

        [TestMethod]
        public void game_Guess_ResponseDataAreAdded()
        {
            //Arrage
            var guess = "money";

            //Act
            game.GuessCheck(guess);
            game.GetResponse(guess);

            Console.WriteLine(String.Join(", ", game.lettersNotInWord.ToArray()));
            Console.WriteLine(String.Join(", ", game.lettersInWordDiferentPlace.ToArray()));
            Console.WriteLine(String.Join("", game.guesedletters));

            //Asser
            Assert.AreEqual(guess, game.nameToGuess);
        }
    }
}