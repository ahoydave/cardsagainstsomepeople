using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cardstake1.Models
{
    public class CardRepo
    {
        private IEnumerator<Card> _questionCards = null;
        private IEnumerator<Card> _answerCards = null;

        public CardRepo(String cardsJson)
        {
            LoadCards(cardsJson);
        }

        public CardRepo()
        {
            LoadCards(System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/cards.json")));
        }

        public Card GetNextAnswer()
        {
            if (_answerCards.MoveNext())
                return _answerCards.Current;
            else
            {
                _answerCards.Reset();
                _answerCards.MoveNext();
                return _answerCards.Current;
            }
        }

        public Card GetNextQuestion()
        {
            if (_questionCards.MoveNext())
                return _questionCards.Current;
            else
            {
                _questionCards.Reset();
                _questionCards.MoveNext();
                return _questionCards.Current;
            }
        }

        private void LoadCards(String cardsJson)
        {
            var allCards = JsonConvert.DeserializeObject<List<Card>>(cardsJson);
            _questionCards = allCards.Where(x => x.cardType == "Q").GetEnumerator();
            _answerCards = allCards.Where(x => x.cardType == "A").GetEnumerator();
        }
    }
}