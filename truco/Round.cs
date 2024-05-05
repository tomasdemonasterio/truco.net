namespace RoundNS {
    using PlayerNS;
    using DeckNS;
    using CardNS;
    class Round{
        private List<Player> players;
        private Deck deck;

        public Round(List<Player> players, Deck deck){
            this.players = players;
            this.deck = deck;
        }

        public void Start(){
            // Start the round
            giveCards();
            Console.WriteLine("Round started!");
            foreach (Player player in players){
                Console.WriteLine(player.GetName());
                Console.WriteLine("Hand: ");
                foreach (Card card in player.GetHand().GetCards()){
                    Console.WriteLine(card.getSuit() + " " + card.getValue());
                }
            }
        }

        public void giveCards() {
            int i = 0;
            while (i < 3) {
                for (int j = 0; j < players.Count; j++) {
                    players[j].GetHand().AddCard(deck.GetNextCard());
                }
                i++;
            }
        }
    }
}