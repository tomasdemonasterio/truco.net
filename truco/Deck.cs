using CardNS;
using RandomNS;

namespace DeckNS
{
    internal class Deck
    {
        public List<Card> Cards { get; }

        public int CurrentCardIndex { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            CreateDeck();
            CurrentCardIndex = 0;
        }

        private void CreateDeck()
        {
            for (int i = 1; i < 8; i++)
            {
                AddCard(new Card(Suits.Bastos, i));
                AddCard(new Card(Suits.Copas, i));
                AddCard(new Card(Suits.Espadas, i));
                AddCard(new Card(Suits.Oros, i));
            }

            for (int i = 10; i < 13; i++)
            {
                AddCard(new Card(Suits.Bastos, i));
                AddCard(new Card(Suits.Copas, i));
                AddCard(new Card(Suits.Espadas, i));
                AddCard(new Card(Suits.Oros, i));
            }
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public Card GetNextCard()
        {
            if (CurrentCardIndex >= Cards.Count)
            {
                throw new Exception("No more cards in the deck");
            }

            Card card = Cards[CurrentCardIndex];
            RemoveCard(CurrentCardIndex);
            CurrentCardIndex++;
            return card;
        }

        public void RemoveCard(int index)
        {
            Cards.RemoveAt(index);
        }

        public void Shuffle()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                int randomIndex = RandomHelper.GetRandomIndex(Cards.Count);
                (Cards[randomIndex], Cards[i]) = (Cards[i], Cards[randomIndex]);
            }
        }
    }
}