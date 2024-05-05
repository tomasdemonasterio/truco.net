namespace HandNS {
    using CardNS;
    using DeckNS;

    class Hand {
        private Dictionary<int, Card> cards;
        
        public Hand() {
            cards = new Dictionary<int, Card>();
        }

        public void AddCard(int index, Card card) {
            cards.Add(index, card);
        }

        public void removeCard(int index) {
            cards.Remove(index);
        }

        public List<Card> GetCards() {
            return cards.Values.ToList();
        }
    }
}