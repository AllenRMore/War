using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player1 = new Player("Steve");
            Player player2 = new Player("Steve2");
            Player player3 = new Player("Steve3");

            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            Game game = new Game(players, deck);

            // Plays a game and prints out the winner.
            Console.WriteLine(game.Play());
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
}
