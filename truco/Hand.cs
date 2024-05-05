namespace HandNS {
    using CardNS;
    using DeckNS;

    class Hand {
        private HashSet<Card> cards;
        
        public Hand() {
            cards = new HashSet<Card>();
        }

        public void AddCard(Card card) {
            cards.Add(card);
        }

        public void removeCard(Card card) {
            cards.Remove(card);
        }

        public HashSet<Card> GetCards() {
            return cards;
        }
    }
}