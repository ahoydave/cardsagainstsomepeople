using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cardstake1.Controllers;
using System.Collections;
using cardstake1.Models;
using System.Linq;

namespace cardstake1.Tests
{
    [TestClass]
    public class TestCardRepo
    {
        private string testJson = @"[{'id':1,'cardType':'Q','text':'Test','numAnswers':1,'expansion': 'Base'},
            {'id':2,'cardType':'A','text':'Michelle Obamas arms.','numAnswers':0,'expansion': 'Base'},
            {'id':3,'cardType':'A','text':'German dungeon porn.','numAnswers':0,'expansion': 'Base'}]";

        [TestMethod]
        public void TestGetNextAnswer()
        {
            CardRepo repo = new CardRepo(testJson);
            var card1 = repo.GetNextAnswer();
            var card2 = repo.GetNextAnswer();
            Assert.AreEqual("Michelle Obamas arms.", card1.text);
            Assert.AreEqual("German dungeon porn.", card2.text);
        }

        [TestMethod]
        public void TestGetQuestion()
        {
            CardRepo repo = new CardRepo(testJson);
            var card = repo.GetNextQuestion();
            Assert.AreEqual("Test", card.text);
        }
    }
}
