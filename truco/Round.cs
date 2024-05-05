namespace RoundNS {
    using PlayerNS;
    using DeckNS;
    using CardNS;
    class Round{
        private List<Player> players;
        private Deck deck;
        private int roundScore;

        public Round(List<Player> players, Deck deck){
            this.players = players;
            this.deck = deck;
            this.roundScore = 0;
        }

        public void Start(){
            // Start the round
        }

        public void SetRoundScore(int roundScore){
            this.roundScore = roundScore;
        }

        public void giveCards() {
            int i = 0;
            while (i < 3) {
                for (int j = 0; j < players.Count; j++) {
                    players[j].GetHand().AddCard(deck.getNextCard());
                }
                i++;
            }
        }
    }
}