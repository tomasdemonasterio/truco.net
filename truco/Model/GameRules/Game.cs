using PlayerNS;
using RoundNS;

/// <summary>
/// Represents a game.
/// </summary>
namespace GameNS
{
    /// <summary>
    /// Represents a game of Truco.
    /// </summary>
    internal class Game
    {
        public List<Player> Players { get; set; }
        public int RoundNumber { get; set; }
        public Round? Round { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            Players = new List<Player>();
            RoundNumber = 0;
            Round = null;
        }

        /// <summary>
        /// Adds a player to the game.
        /// </summary>
        /// <param name="player">The player to add.</param>
        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        /// <summary>
        /// Removes a player from the game.
        /// </summary>
        /// <param name="player">The player to remove.</param>
        public void RemovePlayer(Player player)
        {
            _ = Players.Remove(player);
        }

        /// <summary>
        /// Starts a new round of the game.
        /// </summary>
        public void StartNewRound()
        {
            // Start the game
            Round = new Round(Players);
            Round.StartRound();
            RoundNumber++;
        }

        /// <summary>
        /// Checks if any player has reached the maximum score.
        /// </summary>
        /// <returns><c>true</c> if any player has reached the maximum score; otherwise, <c>false</c>.</returns>
        public bool AnyPlayerGotMaxScore()
        {
            foreach (Player player in Players)
            {
                if (player.Score >= 30)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the winner of the game.
        /// </summary>
        /// <returns>The player who has the highest score.</returns>
        public Player GetWinner()
        {
            Player winner = Players[0];
            foreach (Player player in Players)
            {
                if (player.Score > winner.Score)
                {
                    winner = player;
                }
            }
            return winner;
        }
    }
}