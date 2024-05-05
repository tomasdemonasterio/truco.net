namespace RoundNS {
    using PlayerNS;
    using DeckNS;
    using CardNS;

    enum RoundState {
        start,
        Truco,
        Retruco,
        ValeCuatro,
        Envido,
        RealEnvido,
        FaltaEnvido,
        FaltaTruco,
        Quiero,
    }
    class Round{
        private List<Player> players;
        private Deck deck;
        public int roundScore { get; set;}

        public RoundState roundState { get; set;}

        public Round(List<Player> players, Deck deck){
            this.players = players;
            this.deck = deck;
            this.roundScore = 0;
            this.roundState = RoundState.start;
        }

        public void Start(){
            // Start the round
        }

        public void giveCards() {
            int i = 0;
            while (i < 3) {
                foreach (Player player in players) {
                    player.GetHand().AddCard(i, deck.getNextCard());
                }
                i++;
            }
        }
    }
}