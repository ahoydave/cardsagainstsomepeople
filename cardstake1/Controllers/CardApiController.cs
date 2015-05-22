using cardstake1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Web;

namespace cardstake1.Controllers
{
    public class CardApiController : ApiController
    {
        [Route("api/cardapi/A"), HttpGet]
        public Card GetAnswer()
        {
            return CahGame.Instance.DrawAnswerCard();
        }

        [Route("api/cardapi/Q"), HttpGet]
        public Card GetQuestion()
        {
            return CahGame.Instance.GetQuestion();
        }

        [Route("api/cardapi/{playerid}/submitA"), HttpPost]
        public void SubmitCard(String playerId, Card card)
        {
            CahGame.Instance.SubmitAnswer(card, playerId);
        }

        [Route("api/cardapi/getsubmittedAs"), HttpGet]
        public IEnumerable<Card> GetSubmittedAs()
        {
            return CahGame.Instance.GetSubmittedAnswers();
        }

        [Route("api/cardapi/chooseA"), HttpPost]
        public void ChooseAnswer(Card card)
        {
            CahGame.Instance.ChooseAnswer(card);
        }

        [Route("api/cardapi/{playerId}/didIwin"), HttpGet]
        public bool ChooseAnswer(String playerId)
        {
            return CahGame.Instance.CheckIfWon(playerId);
        }
    }
}
