using PlayerNS;
using RoundNS;

namespace GameNS
{
    internal class Game
    {
        public List<Player> Players { get; set; }
        public int RoundNumber { get; set; }
        public Round? Round { get; set; }

        public Game()
        {
            Players = new List<Player>();
            RoundNumber = 0;
            Round = null;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            _ = Players.Remove(player);
        }

        public void StartNewRound()
        {
            // Start the game
            Round = new Round(Players);
            Round.StartRound();
            RoundNumber++;
        }

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