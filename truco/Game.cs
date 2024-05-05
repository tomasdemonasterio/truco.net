namespace GameNS {
    using DeckNS;
    using PlayerNS;
    using RoundNS;

    class Game {
        private List<Player> players;
        private Deck deck;
        private int roundNumber;

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

            Round round = new Round(players, deck);
            roundNumber++;

            round.giveCards();

            round.Start();
        }


        public void End() {
            // End the game
        }
    }
}