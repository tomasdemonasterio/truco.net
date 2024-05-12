using GameNS;
using PlayerNS;

/// <summary>
/// The <c>UINS</c> namespace contains classes related to the user interface of the Truco game.
/// </summary>
namespace UINS
{
    /// <summary>
    /// Represents the user interface for the Truco game.
    /// </summary>
    internal class UserInterface
    /// <summary>
    /// Represents the user interface for the Truco game.
    /// </summary>
    {
        /// <summary>
        /// Starts the Truco game.
        /// </summary>
        public static void Start()
        {
            Game game = StartGame();
            while (!game.AnyPlayerGotMaxScore())
            {
                StartRound(game);
            }
            EndGame(game);
        }

        /// <summary>
        /// Ends the Truco game and displays the winner.
        /// </summary>
        /// <param name="game">The Truco game.</param>
        public static void EndGame(Game game)
        {
            Console.WriteLine("The winner is: " + game.GetWinner().Name + " with " + game.GetWinner().Score + " points!");
        }

        /// <summary>
        /// Starts a new Truco game and initializes the players.
        /// </summary>
        /// <returns>The Truco game.</returns>
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

        /// <summary>
        /// Starts a new round in the Truco game.
        /// </summary>
        /// <param name="game">The Truco game.</param>
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
                    if (game.Round.PlayerTurn.AvailableActions.Count == 1) {
                        game.Round.PlayerTurn = player;
                    }
                }
            }
            game.Round.EndRound();
            Console.WriteLine("Round ended!");
            foreach (Player player in game.Players)
            {
                Console.WriteLine(player.Name + "'s score: " + player.Score);
            }
        }

        /// <summary>
        /// Displays the player's hand.
        /// </summary>
        /// <param name="player">The player.</param>
        public static void ShowPlayerHand(Player player)
        {
            Console.WriteLine(player.Name + "'s hand:");
            Console.WriteLine(player.Hand.ToString());
            Console.WriteLine("Envido value: " + player.Hand.EnvidoTotalValue);
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the player's available actions.
        /// </summary>
        /// <param name="player">The player.</param>
        public static void ShowPlayerAvailableActions(Player player)
        {
            Console.WriteLine(player.Name + "'s available actions");
            Console.WriteLine(player.PlayerAvailableActionsToString());
            Console.WriteLine();
        }

        /// <summary>
        /// Reads the player's action and performs the corresponding action in the Truco game.
        /// </summary>
        /// <param name="game">The Truco game.</param>
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
                            {Acciones.QuieroTruco, Acciones.Envido, Acciones.Retruco});
                            break;
                        }
                        if (action.Equals("retruco", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.Retruco, new List<Acciones>
                            {Acciones.QuieroTruco, Acciones.ValeCuatro});
                            break;
                        }
                        if (action.Equals("valecuatro", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.ValeCuatro, new List<Acciones>
                            {Acciones.QuieroTruco});
                            break;
                        }
                        if (action.Equals("envido", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.Envido, new List<Acciones>
                            {Acciones.QuieroEnvido, Acciones.NoQuiero, Acciones.RealEnvido});
                            break;
                        }
                        if (action.Equals("realenvido", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.RealEnvido, new List<Acciones>
                            {Acciones.QuieroEnvido, Acciones.NoQuiero, Acciones.FaltaEnvido});
                            break;
                        }
                        if (action.Equals("faltaenvido", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.FaltaEnvido, new List<Acciones>
                            {Acciones.QuieroEnvido, Acciones.NoQuiero});
                            break;
                        }
                        if (action.Equals("irsealmazo", StringComparison.Ordinal))
                        {
                            game.Round.PlayerSeFueAlMazo(player);
                            game.Round.IsRoundEnded = true;
                            break;
                        }
                        if (action.Equals("quierotruco", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.QuieroTruco, new List<Acciones>
                            {Acciones.Pasar});
                            break;
                        }
                        if (action.Equals("quieroenvido", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.QuieroTruco, new List<Acciones>
                            {Acciones.Truco, Acciones.Pasar});
                            break;
                        }
                        if (action.Equals("noquiero", StringComparison.Ordinal))
                        {
                            game.Round.AccionCantada(player, Acciones.QuieroTruco, new List<Acciones>
                            {Acciones.Truco, Acciones.Pasar});
                            break;
                        }
                        if (action.Equals("pasar", StringComparison.Ordinal))
                        {
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