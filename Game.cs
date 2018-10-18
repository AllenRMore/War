using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace War
{
    class Game
    {
        private List<Player> players;
        private Deck deck;
        private CardStack pot;

        // Mainly for testing reasons
        public Dictionary<String, List<int>> Ledger { get; set; }

        public Game(List<Player> players, Deck deck)
        {
            this.players = players;
            this.deck = deck;
            this.pot = new CardStack();
            this.Deal();
        }

        /*
         * Runs a game to completion and returns a string declaring the winner.
         */
        public String Play()
        {
            // Apparently games of war can go on forever, so I'm putting an upperbound
            // on how many rounds you can play in a single game.
            int rounds = 0;
            int roundBound = 100;

            // Keep looping until only one person has cards or round bound hit.
            while (this.players.Count(x => !x.IsOutOfCards()) > 1 && rounds < roundBound)
            {
                int remaining = this.players.Count(x => !x.IsOutOfCards());
                this.playRound(this.players).Wins++;
                rounds++;
            }

            string winnerName = this.players.OrderByDescending(x => x.Wins).First().Name;

            return winnerName + " Won!";
        }

        /* 
         * Distributes cards among appropriate players. 
         */
        private void Deal()
        {
            int totalCards = deck.Cards.Count;
            for(int i = 0; i < totalCards; i++)
            {
                players[i % players.Count].Hand.AddOneCard(deck.DrawOneCard());
            }  
        }

        /*
         * Play one round and return the round winner.
         */
        private Player playRound(List<Player> players)
        {
            int highest = 0;
            List<Player> winning = new List<Player>();

            // Dummy first card
            Card currentCard = new Card((suit)1, 1);

            foreach (Player player in players)
            {
                try
                {
                    // Player places thier card in the CardStack
                    currentCard = player.Hand.DrawOneCard();
                }
                catch (InvalidOperationException)
                {
                    // Skip this player if they don't have cards.
                    continue;
                }

                pot.AddOneCard(currentCard);

                if (currentCard.FaceValue > highest)
                {
                    highest = currentCard.FaceValue;
                    winning.Clear();
                    winning.Add(player);
                }
                else if(currentCard.FaceValue == highest)
                {
                    winning.Add(player);
                }
            }

            // Handle tie
            if(winning.Count > 1)
            {
                // Play subgame
                return playRound(winning);
            }

            // Take pot
            winning[0].Hand.ConsumeCardStack(pot);

            // Return winner
            return winning[0];
        }
    }
}
