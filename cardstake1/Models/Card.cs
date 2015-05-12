using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cardstake1.Models
{
    public class Card
    {
        public int id { get; set; }
        public string cardType { get; set; }
        public string text { get; set; }
        public int numAnswers { get; set; }
        public string expansion { get; set; }
    };
}