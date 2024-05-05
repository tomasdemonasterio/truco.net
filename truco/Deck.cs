using CardNS;

namespace DeckNS {
    class Deck {
        private List<Card> cards;
        private int currentCardIndex;

        public Deck() {
            this.cards = new List<Card>();
            CreateDeck();
            this.currentCardIndex = 0;
        }

        private void CreateDeck() {
            for (int i = 1; i <= 8; i++) {
                AddCard(new Card(Suits.Bastos, i));
                AddCard(new Card(Suits.Copas, i));
                AddCard(new Card(Suits.Espadas, i));
                AddCard(new Card(Suits.Oros, i));
            }

            AddCard(new Card(Suits.Bastos, 10));
            AddCard(new Card(Suits.Copas, 10));
            AddCard(new Card(Suits.Espadas, 10));
            AddCard(new Card(Suits.Oros, 10));
        }

        public void AddCard(Card card) {
            this.cards.Add(card);
        }

        public Card GetNextCard() {
            if (this.currentCardIndex >= this.cards.Count) {
                throw new Exception("No more cards in the deck");
            }

            Card card = this.cards[this.currentCardIndex];
            this.currentCardIndex++;
            return card;
        }

        public void Shuffle() {
            Random random = new Random();
            for (int i = 0; i < this.cards.Count; i++) {
                int randomIndex = random.Next(0, this.cards.Count);
                Card temp = this.cards[i];
                this.cards[i] = this.cards[randomIndex];
                this.cards[randomIndex] = temp;
            }
        }
    }
}