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

            int phases = 0;

            while(phases < 4) {
                Console.WriteLine("Round state: " + game.round.roundState);
                Player player = game.round.nextPlayer;
                Console.WriteLine(player.name + "'s turn:");
                showPlayerAvailableActions(player);
                showPlayerHand(player);
                readAction(game);
                game.round.nextPlayer = game.players.Find(p => p != player);
                phases++;
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
                    string action = Console.ReadLine();
                    if (Enum.TryParse(action, out Acciones accion)) {
                        if (player.availableActions.Contains(accion)) {
                            if (action.Equals("Truco")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.Retruco, Acciones.IrseAlMazo}, RoundState.Truco);
                                player.playerState = PlayerState.isPlayingTruco;
                                break;
                            }
                            if (action.Equals("Envido")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.RealEnvido, Acciones.IrseAlMazo}, RoundState.Envido);
                                player.playerState = PlayerState.isPlayingEnvido;
                                break;
                            }
                            if (action.Equals("RealEnvido")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.FaltaEnvido, Acciones.IrseAlMazo}, RoundState.RealEnvido);
                                player.playerState = PlayerState.isPlayingRealEnvido;
                                break;
                            }
                            if (action.Equals("Retruco")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.ValeCuatro, Acciones.IrseAlMazo}, RoundState.Retruco);
                                player.playerState = PlayerState.isPlayingRetruco;
                                break;
                            }
                            if (action.Equals("ValeCuatro")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.IrseAlMazo}, RoundState.ValeCuatro);
                                player.playerState = PlayerState.isPlayingValeCuatro;
                                break;
                            }
                            if (action.Equals("FaltaEnvido")) {
                                game.round.accionCantada(player, new List<Acciones> {Acciones.Quiero, Acciones.IrseAlMazo}, RoundState.FaltaEnvido);
                                player.playerState = PlayerState.isPlayingFaltaEnvido;
                                break;
                            }
                            if (action.Equals("IrseAlMazo")) {
                                // Debe terminar la ronda TODO
                                player.playerState = PlayerState.isPlayingIrseAlMazo;
                                game.round.endRound();
                                break;
                            }
                            if (action.Equals("Quiero")) {
                                // Debe terminar la ronda TODO
                                player.playerState = PlayerState.isPlayingQuiero;
                                break;
                                }
                            if (action.Equals("Pasar")) {
                                // TODO
                                showPlayerHand(player);
                                Console.WriteLine("Enter the card index to pass:");
                                player.playCard(int.Parse(Console.ReadLine()));
                                player.playerState = PlayerState.isPlayingPasar;
                                break;
                            }
                    }
                }
                    Console.WriteLine("Invalid action");
                }
        }
    }
}