using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace War
{
    class Deck : CardStack
    {
        public Deck() : base()
        {
            this.GenerateCards();
            this.Shuffle();
        }

        /*
         * Generates a standard 52 card deck.
         */
        protected void GenerateCards()
        {
            // Keeps track of how many duplicates need to be made.
            int dupIter = 0;
            int faceValue = 1;
            for (int i = 0; i < 52; i++)
            {
                // Increment face value when duplicates for that value have been created.
                if (dupIter > 3)
                {
                    faceValue++;
                    dupIter = 0;
                }
                suit currentSuit = (suit)(i % 4);
                Card nextCard = new Card(currentSuit, faceValue);
                this.Cards.Push(nextCard);
                dupIter++;
            }
        }

        /*
         * Randomizes card position in the stack.
         */
        protected void Shuffle()
        {
            Random shuffleSeed = new Random();

            SortedDictionary<int, Card> dShuffle = new SortedDictionary<int, Card>();

            while (this.Cards.Count > 0)
            {
                Card insert = this.Cards.Pop();
                // Inserts card into a random location in the hashtable
                dShuffle[((int)(insert.GetHashCode() * shuffleSeed.NextDouble()))] = insert;
            }

            // Squash that hash table into a list, preserving order.
            List<Card> lShuffle = dShuffle.Values.ToList();

            Stack<Card> shuffledCards = new Stack<Card>();

            foreach (Card card in lShuffle)
            {
                shuffledCards.Push(card);
            }

            this.Cards = shuffledCards;
        }
    }
}
