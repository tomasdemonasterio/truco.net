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

        public Dictionary<int, Card> GetCards() {
            return cards;
        }
        public Card GetCard(int index) {
            return cards[index];
        }
        
        public string toString() {
            string result = "";
            foreach (KeyValuePair<int, Card> entry in cards)
            {
                result += entry.Key + ". "  + entry.Value.getSuit() + " " + entry.Value.getNumber() + " Valor: " + entry.Value.getValue() + "\n";
            }
            if (result == "") {
                result = "Empty hand";
            }
            return result;
        }
    }
}