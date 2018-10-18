using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace War
{
    class CardStack
    {
        public Stack<Card> Cards { get; set; }
        public CardStack()
        {
            this.Cards = new Stack<Card>();
        }

        public Card DrawOneCard()
        {
            return this.Cards.Pop();
        }

        public void AddOneCard(Card card)
        {
            this.Cards.Push(card);
        }

        /*
         * Adds a passed CardStack to the bottom of this CardStack, preserving order.
         */
        public void ConsumeCardStack(CardStack food)
        {
            List<Card> foodStage = new List<Card>();

            // Invert passed stack onto stage
            int j = food.Cards.Count;
            for (int i = 0; i < j; i++)
            {
                foodStage.Add(food.Cards.Pop());
            }

            List<Card> stage = new List<Card>();

            // Same process for this
            int k = this.Cards.Count;
            for (int i = 0; i < k; i++)
            {
                stage.Add(this.Cards.Pop());
            }

            stage.AddRange(foodStage);

            // Invert to reclaim original order with this on top
            stage.Reverse();

            Stack<Card> newCards = new Stack<Card>();
            
            // Push cards from stage into a new Stack
            foreach(Card card in stage)
            {
                newCards.Push(card);
            }

            this.Cards = newCards;
        }
    }
}
