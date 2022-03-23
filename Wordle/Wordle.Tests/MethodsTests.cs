using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wordle.Tests
{
    [TestClass]
    public class MethodsTests
    {
        public Methods game;

        [TestInitialize]
        public void Setup()
        {
            game = new Methods();
        }

        [TestMethod]
        public void GetUnknownWord_CallFunction_NotNull()
        {
            //Act
            game.GetUnknownWord();

            //Asser
            Assert.IsNotNull(game.nameToGuess);
        }

        [DataTestMethod]
        [DataRow("rtudt")]
        [DataRow("")]
        [DataRow("a a a")]
        [DataRow("aa")]
        public void GivenNameValid_NotAName_IsFalse(string wordTest)
        {
            //Act
            bool result = game.GuessNameValid(wordTest);

            //Asser
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("sound")]
        [DataRow("Sound")]
        public void GivenNameValid_NotAName_IsTrue(string wordTest)
        {
            //Act
            bool result = game.GuessNameValid(wordTest);

            //Asser
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GuessCheck_CheckGuesedWord_False()
        {
            //Arrage
            var guess = "where";

            //Act
            bool result = game.GuessCheck(guess);

            //Asser
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GuessCheck_CheckGuesedWord_True()
        {
            //Arrage
            var guess = game.nameToGuess;

            //Act
            bool result = game.GuessCheck(guess);

            //Asser
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetResponse_Guess_ResponseDataAreAdded()
        {
            //Arrage
            game.nameToGuess = "price";
            var guess = "purse";
            var lettersNotInWord = new List<char>() {'u', 's'};
            var lettersInWordDiferentPlace = new List<char>() {'r'};
            var guesedletters = "p___e";

            //Act
            game.GetResponse(guess);

            //Asser
            CollectionAssert.AreEqual(lettersNotInWord, game.lettersNotInWord.ToList());
            CollectionAssert.AreEqual(lettersInWordDiferentPlace, game.lettersInWordDiferentPlace.ToList());
            Assert.AreEqual(guesedletters, string.Join("", game.guesedletters));
        }
    }
}
