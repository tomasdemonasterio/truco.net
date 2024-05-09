using GameNS;
using PlayerNS;

namespace UINS
{
    internal class UserInterface
    {
        public static void Start()
        {
            Game game = StartGame();
            while (!game.AnyPlayerGotMaxScore())
            {
                StartRound(game);
            }
            EndGame(game);
        }

        public static void EndGame(Game game)
        {
            Console.WriteLine("The winner is: " + game.GetWinner().Name + " with " + game.GetWinner().Score + " points!");
        }

        public static Game StartGame()
        {
            Game game = new();
            Console.WriteLine("Welcome to Truco!");
            Console.WriteLine("Player 1, please enter your name: ");
            game.Players.Add(new Player(Console.ReadLine(), game));
            Console.WriteLine("Player 2, please enter your name: ");
            game.Players.Add(new Player(Console.ReadLine(), game));
            return game;
        }

        public static void StartRound(Game game)
        {
            game.StartNewRound();
            Console.WriteLine("Round 1 started!");
            Console.WriteLine();

            while (!game.Round.IsRoundEnded)
            {
                Player player = game.Round.PlayerTurn;
                Console.WriteLine(player.Name + "'s turn:");
                ShowPlayerHand(player);
                ShowPlayerAvailableActions(player);
                ReadAction(game);
                if (game.Round.AllPlayersPlayedCard())
                {
                    game.Round.WinnerOfPhase();
                    Console.WriteLine("Winner of the phase: " + game.Round.PlayerTurn.Name);
                }
                else
                {
                    game.Round.PlayerTurn = game.Players.Find(p => p != player);
                }
            }
            game.Round.EndRound();
            Console.WriteLine("Round ended!");
            foreach (Player player in game.Players)
            {
                Console.WriteLine(player.Name + "'s score: " + player.Score);
            }
        }

        public static void ShowPlayerHand(Player player)
        {
            Console.WriteLine(player.Name + "'s hand:");
            Console.WriteLine(player.Hand.ToString());
            Console.WriteLine();
        }

        public static void ShowPlayerAvailableActions(Player player)
        {
            Console.WriteLine(player.Name + "'s available actions");
            Console.WriteLine(player.PlayerAvailableActionsToString());
            Console.WriteLine();
        }

        public static void ReadAction(Game game)
        {
            Player player = game.Round.PlayerTurn;
            Console.WriteLine(player.Name + ", please enter your action:");
            while (true)
            {
                if (game.Round.PlayersInRound.All(static p => p.Hand.Cards.Count == 0))
                {
                    game.Round.IsRoundEnded = true;
                    break;
                }
                string action = Console.ReadLine().ToLower(System.Globalization.CultureInfo.CurrentCulture);
                if (Enum.TryParse(action, true, out Acciones accion))
                {
                    if (player.AvailableActions.Contains(accion))
                    {
                        if (action.Equals("truco", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.Truco, new List<Acciones>
                            {Acciones.Quiero, Acciones.Retruco, Acciones.IrseAlMazo});
                            break;
                        }
                        if (action.Equals("retruco", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.Retruco, new List<Acciones>
                            {Acciones.Quiero, Acciones.ValeCuatro, Acciones.IrseAlMazo});
                            break;
                        }
                        if (action.Equals("valecuatro", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.ValeCuatro, new List<Acciones>
                            {Acciones.Quiero, Acciones.IrseAlMazo});
                            break;
                        }
                        if (action.Equals("envido", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.Envido, new List<Acciones>
                            {Acciones.Quiero, Acciones.RealEnvido, Acciones.IrseAlMazo});
                            break;
                        }
                        if (action.Equals("realenvido", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.RealEnvido, new List<Acciones>
                            {Acciones.Quiero, Acciones.FaltaEnvido, Acciones.IrseAlMazo});
                            break;
                        }
                        if (action.Equals("faltaenvido", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.FaltaEnvido, new List<Acciones>
                            {Acciones.Quiero, Acciones.IrseAlMazo});
                            break;
                        }
                        if (action.Equals("irsealmazo", StringComparison.Ordinal))
                        {
                            game.Round.PlayerSeFueAlMazo(player);
                            game.Round.IsRoundEnded = true;
                            break;
                        }
                        if (action.Equals("quiero", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.Quiero, new List<Acciones>
                            {Acciones.Pasar, Acciones.IrseAlMazo});
                            break;
                        }
                        if (action.Equals("pasar", StringComparison.Ordinal))
                        {
                            // Si todos los jugadores ya pusieron todas las cartas, terminar la ronda
                            Console.WriteLine("Enter the card index to pass:");
                            player.PlayCard(int.Parse(Console.ReadLine()));
                            break;
                        }
                    }
                }
                Console.WriteLine("Invalid action");
            }
        }
    }
}