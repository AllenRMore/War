using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    class Player
    {
        public int Wins { get; set; }

        public CardStack Hand { get; set; }

        public String Name { get; set; }

        public Boolean IsOutOfCards()
        {
            return this.Hand.Cards.Count < 1;
        }

        public Player(String name)
        {
            this.Name = name;
            this.Wins = 0;
            this.Hand = new CardStack();
        }
    }
}
