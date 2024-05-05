namespace HandNS {
    using CardNS;
    class Hand {
        private List<Card> cards;
        
        public Hand() {
            cards = new List<Card>();
        }

        public void AddCard(Card card) {
            cards.Add(card);
        }

        public void removeCard(Card card) {
            cards.Remove(card);
        }

        public List<Card> GetCards() {
            return cards;
        }
    }
}