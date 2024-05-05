namespace UINS
{
    using GameNS;
    using PlayerNS;
    using CardNS;
    using RoundNS;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using System.Security.Cryptography.X509Certificates;

    class UserInterface
    {
        public static void start()
        {
            List<Player> players = new List<Player>();
            Game game = new Game(players);
            Console.WriteLine("Welcome to Truco!");
            Console.WriteLine("Player 1, please enter your name: ");
            players.Add(new Player(Console.ReadLine(), game));
            Console.WriteLine("Player 2, please enter your name: ");
            players.Add(new Player(Console.ReadLine(), game));
            game.Start();

            Console.WriteLine("Round 1 started!");
            Console.WriteLine();

            Player currentPlayer = players[0];
            while(true) {
                Console.WriteLine("Round state: " + game.round.roundState);
                if (game.round.roundState == RoundState.Truco){
                    hadTruco(currentPlayer);
                    currentPlayer = players[0];
                    continue;
                }
                if (game.round.roundState == RoundState.Envido){
                    hadEnvido(currentPlayer);
                    currentPlayer = players[0];
                    continue;
                }
                if(game.round.roundState == RoundState.RealEnvido){
                    hadRealEnvido(currentPlayer);
                    currentPlayer = players[1];
                    continue;
                }
                if(game.round.roundState == RoundState.Retruco){
                    hadRetruco(currentPlayer);
                    currentPlayer = players[1];
                    continue;
                }
                firstPhase(currentPlayer);
                currentPlayer = players[1];
            }
        }

        public static void showPlayerHand(Player player)
        {
            Console.WriteLine(player.GetName() + "'s hand:");
            int i = 0;
            foreach (Card card in player.GetHand().GetCards())
            {
                Console.WriteLine(i + ". "  + card.getSuit() + " " + card.getNumber());
                i++;
            }
            Console.WriteLine();
        }

        public static void firstPhase(Player player)
        {
            Console.WriteLine(player.GetName() + "'s turn:");
            Console.WriteLine("Enter the number for the action: ");
            Console.WriteLine("1. Envido");
            Console.WriteLine("2. Truco");
            Console.WriteLine("3. Pasar");
            Console.WriteLine("4. Irse al mazo");
            Console.WriteLine();

            int command = int.Parse(Console.ReadLine());
            if (command == 1){
                player.envido();
            }
            if (command == 2){
                player.truco();
            }
            if (command == 3){
                Console.WriteLine("Enter the card index to pass:");
                player.pasar(int.Parse(Console.ReadLine()));
            }
            if (command == 4){
                player.irseAlMazo();
            }
            Console.WriteLine();
        }

        public static void hadEnvido(Player player) {
            Console.WriteLine(player.GetName() + "'s turn:");
            Console.WriteLine("Envido is active!");
            Console.WriteLine();
            Console.WriteLine("1. Quiero");
            Console.WriteLine("2. Real Envido");
            Console.WriteLine("3. Falta Envido");
            int command = int.Parse(Console.ReadLine());
            if (command == 1){
                player.quiero();
            }
            if (command == 2){
                player.realEnvido();
            }
            if (command == 3){
                player.faltaEnvido();
            }
        }

        public static void hadRealEnvido(Player player) {
            Console.WriteLine(player.GetName() + "'s turn:");
            Console.WriteLine("Real Envido is active!");
            Console.WriteLine();
            Console.WriteLine("1. Quiero");
            Console.WriteLine("2. Falta Envido");
            int command = int.Parse(Console.ReadLine());
            if (command == 1){
                player.quiero();
            }
            if (command == 2){
                player.faltaEnvido();
            }
        }

         public static void hadTruco(Player player) {
            Console.WriteLine(player.GetName() + "'s turn:");
            Console.WriteLine("Truco is active!");
            Console.WriteLine();
            Console.WriteLine("1. Quiero");
            Console.WriteLine("2. Retruco");
            Console.WriteLine("3. Falta truco");
            int command = int.Parse(Console.ReadLine());
            if (command == 1){
                player.quiero();
            }
            if (command == 2){
                player.retruco();
            }
            if (command == 3){
                player.faltaTruco();
            }
        }

        public static void hadRetruco(Player player) {
            Console.WriteLine(player.GetName() + "'s turn:");
            Console.WriteLine("Retruco is active!");
            Console.WriteLine();
            Console.WriteLine("1. Quiero");
            Console.WriteLine("2. Vale Cuatro");
            Console.WriteLine("3. Falta truco");
            int command = int.Parse(Console.ReadLine());
            if (command == 1){
                player.quiero();
            }
            if (command == 2){
                player.valeCuatro();
            }
            if (command == 3){
                player.faltaTruco();
            }
        }
    }
}