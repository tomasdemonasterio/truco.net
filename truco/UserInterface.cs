namespace UINS
{
    using GameNS;
    using PlayerNS;
    using RoundNS;
    using System;
    using System.Collections.Generic;

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

            int playedCards = 0;
            while(game.round.roundState != RoundState.Ended) {
                Console.WriteLine("Round state: " + game.round.roundState);
                Player player = game.round.nextPlayer;
                Console.WriteLine(player.name + "'s turn:");
                showPlayerHand(player);
                showPlayerAvailableActions(player);
                readAction(game);
                game.round.nextPlayer = game.players.Find(p => p != player);
                if (game.round.roundState == RoundState.CardPlayed) {
                    playedCards++;
                }
                if (playedCards == game.round.playersInRound.Count || game.round.roundState == RoundState.Ended) {
                    game.round.winnerOfPhase();
                    playedCards = 0;
                }
        }
            Console.WriteLine("Round ended!");
            foreach (Player player in game.players) {
                Console.WriteLine(player.name + "'s score: " + player.score);
            }
    }
        public static void showPlayerHand(Player player)
        {
            Console.WriteLine(player.name + "'s hand:");
            Console.WriteLine(player.hand.toString());
            Console.WriteLine();
        }

        public static void showPlayerAvailableActions(Player player)
        {
            Console.WriteLine(player.name + "'s available actions");
            Console.WriteLine(player.playerAvailableActionsToString());
            Console.WriteLine();
        }

        public static void readAction(Game game)
        {
            Player player = game.round.nextPlayer;
            Console.WriteLine(player.name + ", please enter your action:");
            while (true) {
                if (game.round.playersInRound.All(p => p.hand.GetCards().Count == 0)) {
                    game.round.roundState = RoundState.Ended;
                    game.round.endRound();
                    break;
                }
                string action = Console.ReadLine().ToLower();
                if (Enum.TryParse(action, true, out Acciones accion)) {
                    if (player.availableActions.Contains(accion)) {
                        if (action.Equals("truco")) {
                            game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.Retruco, Acciones.IrseAlMazo}, RoundState.Truco);
                            game.round.roundScore = 2;
                            break;
                        }
                        if (action.Equals("envido")) {
                            game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.RealEnvido, Acciones.IrseAlMazo}, RoundState.Envido);
                            game.round.roundScore = 99;
                            break;
                            }
                            if (action.Equals("realenvido")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.FaltaEnvido, Acciones.IrseAlMazo}, RoundState.RealEnvido);
                                game.round.roundScore = 99;
                                break;
                            }
                            if (action.Equals("retruco")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.ValeCuatro, Acciones.IrseAlMazo}, RoundState.Retruco);
                                game.round.roundScore = 3;
                                break;
                            }
                            if (action.Equals("valecuatro")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.IrseAlMazo}, RoundState.ValeCuatro);
                                game.round.roundScore = 4;
                                break;
                            }
                            if (action.Equals("faltaenvido")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.IrseAlMazo}, RoundState.FaltaEnvido);
                                game.round.roundScore = 99;
                                break;
                            }
                            if (action.Equals("irsealmazo")) {
                                // Debe terminar la ronda TODO
                                game.round.playerSeFueAlMazo(player);
                                game.round.roundState = RoundState.Ended;
                                game.round.endRound();
                                break;
                            }
                            if (action.Equals("quiero")) {
                                // Debe terminar la ronda TODO
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Pasar, Acciones.IrseAlMazo}, RoundState.Quiero);
                                break;
                                }
                            if (action.Equals("pasar")) {
                                // TODO
                                // Si todos los jugadores ya pusieron todas las cartas, terminar la ronda
                                Console.WriteLine("Enter the card index to pass:");
                                player.playCard(int.Parse(Console.ReadLine()));
                                game.round.roundState = RoundState.CardPlayed;
                                break;
                            }
                    }
                }
                    Console.WriteLine("Invalid action");
                }
        }
    }
}