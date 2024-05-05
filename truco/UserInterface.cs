namespace UINS
{
    using GameNS;
    using PlayerNS;
    using CardNS;
    using RoundNS;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    class UserInterface
    {
        public static void start()
        {
            List<Player> players = new List<Player>();
            Console.WriteLine("Welcome to Truco!");
            Console.WriteLine("Player 1, please enter your name: ");
            players.Add(new Player(Console.ReadLine()));
            Console.WriteLine("Player 2, please enter your name: ");
            players.Add(new Player(Console.ReadLine()));

            Game game = new Game(players);
            game.Start();
            Console.WriteLine("Round started!");
            Console.WriteLine();
            foreach (Player player in players){
                
                Console.WriteLine(player.GetName());
                foreach (Card card in player.GetHand().GetCards()){
                    Console.WriteLine(card.getSuit() + " " + card.getNumber());
                }
                Console.WriteLine();
            }
        }
    }
}