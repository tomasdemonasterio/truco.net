namespace GameNS {
    using DeckNS;
    using PlayerNS;
    using RoundNS;
    using RandomNS;

    class Game {
        public List<Player> players { get; set;}
        private Deck deck;
        private int roundNumber;
        public Round round { get; set;}

        public Game(List<Player> players) {
            this.players = players;
            deck = new Deck();
            roundNumber = 0;
        }

        public void AddPlayer(Player player) {
            players.Add(player);
        }

        public void RemovePlayer(Player player) {
            players.Remove(player);
        }

        public void Start() {
            // Start the game
            deck.Shuffle();
            round = new Round(players, deck);
            roundNumber++;

            round.giveCards();
            int nextPlayerIndex = RandomHelper.GetRandomIndex(players.Count);
            round.nextPlayer = players[nextPlayerIndex];

            //round.Start();
        }

        public void End() {
            // End the game
        }
    }
}