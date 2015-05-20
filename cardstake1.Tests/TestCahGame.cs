using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cardstake1.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace cardstake1.Tests
{
    [TestClass]
    public class TestCahGame
    {
        [TestMethod]
        public void PlayAGameTest1()
        {
            CahGame game = new CahGame(File.ReadAllText("cards.json"));
            Assert.AreEqual(GameState.FirstDraw, game.GameState);

            var cards1 = new List<Card>();
            var cards2 = new List<Card>();
            
            //draw cards
            for (int i = 0; i < 10; i++)
            {
                cards1.Add(game.DrawAnswerCard());
                cards2.Add(game.DrawAnswerCard());
            }

            var question = game.GetQuestion();

            Assert.AreEqual(GameState.SubmitAnswers, game.GameState);

            game.SubmitAnswer(cards1[0], 0);
            game.SubmitAnswer(cards2[0], 1);
            var answers = game.GetSubmittedAnswers();

            Assert.AreEqual(GameState.PickWinner, game.GameState);
            game.ChooseAnswer(cards1[0]);

            Assert.AreEqual(GameState.RoundEnd, game.GameState);
            Assert.IsTrue(game.CheckIfWon(0));
            Assert.IsFalse(game.CheckIfWon(1));

            cards1[0] = game.DrawAnswerCard();
            cards2[0] = game.DrawAnswerCard();
            question = game.GetQuestion();

            Assert.AreEqual(GameState.SubmitAnswers, game.GameState);
        }
    }
}
