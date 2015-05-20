using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cardstake1.Models
{
    public enum GameState { FirstDraw, SubmitAnswers, PickWinner, RoundEnd };

    public class CahGame
    {
        private CardRepo _cards = null;
        private Card _winningCard;
        private int _winningPlayer;
        private Dictionary<int, Card> _submittedAnswers = new Dictionary<int, Card>();

        public GameState GameState { get; set; }

        public CahGame()
        {
            //there shouldnt be this clunky extra constructor
            _cards = new CardRepo();
            GameState = GameState.FirstDraw;
        }

        public CahGame(string cardData)
        {
            _cards = new CardRepo(cardData);
            GameState = GameState.FirstDraw;
        }

        public Card GetQuestion() {
            if (GameState == GameState.FirstDraw || GameState == GameState.RoundEnd)
            {
                Card question = _cards.GetNextQuestion();
                GameState = GameState.SubmitAnswers;
                return question;
            }
            else
                throw new Exception("Asked for Question when game was in state " + GameState);
        }

        public Card DrawAnswerCard()
        {
            //doesn't seem to be much point in restricting this to a particular game state
            return _cards.GetNextAnswer();
        }

        public void SubmitAnswer(Card answer, int playerId)
        {
            if (GameState == GameState.SubmitAnswers)
                if (!_submittedAnswers.ContainsKey(playerId))
                {
                    _submittedAnswers[playerId] = answer;
                }
                else
                {
                    throw new Exception("Tried to submit a card for a player that has already done so this round: player " + playerId);
                }
            else
            {
                throw new Exception("Tried to submit an answer when game was in the state " + GameState);
            }
        }

        public IEnumerable<Card> GetSubmittedAnswers()
        {
            if (GameState == GameState.SubmitAnswers)
            {
                GameState = GameState.PickWinner;
                return _submittedAnswers.Values;
            }
            else
            {
                throw new Exception("Tried to get submitted answers when game was in state " + GameState);
            }
        }

        public void ChooseAnswer(Card answer)
        {
            if (GameState == GameState.PickWinner)
            {
                _winningCard = answer;
                _winningPlayer = _submittedAnswers.Where(x => x.Value.id == answer.id).First().Key;
                GameState = GameState.RoundEnd;
            }
            else
            {
                throw new Exception("Tried to choose answer when game was in state " + GameState);
            }
        }

        public bool CheckIfWon(int playerId)
        {
            if (GameState == GameState.RoundEnd)
            {
                return playerId == _winningPlayer;
            }
            else
            {
                throw new Exception("Tried to check if won when game was in state " + GameState);
            }
        }
    }
}