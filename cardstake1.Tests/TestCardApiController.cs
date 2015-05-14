using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cardstake1.Controllers;
using System.Collections;
using cardstake1.Models;
using System.Linq;

namespace cardstake1.Tests
{
    [TestClass]
    public class TestCardApiController
    {
        private string testJson = @"[{'id':1,'cardType':'A','text':'Test','numAnswers':0,'expansion': 'Base'},
            {'id':2,'cardType':'A','text':'Michelle Obamas arms.','numAnswers':0,'expansion': 'Base'},
            {'id':3,'cardType':'A','text':'German dungeon porn.','numAnswers':0,'expansion': 'Base'}]";

        [TestMethod]
        public void TestGet()
        {

            //var controller = new CardApiController(testJson);
            //Assert.AreEqual(3, controller.Get().Count());
        }
    }
}
