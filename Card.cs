using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public enum suit { hearts, diamonds, spades, clubs };

    class Card
    {
        public suit Suit { get; set; }
        public int FaceValue { get; set; }

        public Card(suit suit, int faceValue)
        {
            this.Suit = suit;
            this.FaceValue = faceValue;
        }
    }
}
