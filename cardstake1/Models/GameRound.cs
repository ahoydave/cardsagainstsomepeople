using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cardstake1.Models
{
    public class GameRound
    {
        public static Card Question { get; set; }
        public static List<Card> SubmittedAnswers { get; set; }
    }
}