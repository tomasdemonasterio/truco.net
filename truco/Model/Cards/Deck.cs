using CardNS;
using RandomNS;

namespace DeckNS
{
    /// <summary>
    /// Class representing a deck of cards
    /// </summary>
    internal class Deck
    {
        /// <summary>
        /// List of cards in the deck
        /// </summary>
        public List<Card> Cards { get; }

        /// <summary>
        /// Index of the current card in the deck
        /// </summary>
        public int CurrentCardIndex { get; set; }

        /// <summary>
        /// Constructor for the Deck class
        /// </summary>
        public Deck()
        {
            Cards = new List<Card>();
            CreateDeck();
            CurrentCardIndex = 0;
        }

        /// <summary>
        /// Method to create a deck of cards
        /// </summary>
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

        /// <summary>
        /// Method to add a card to the deck
        /// </summary>
        /// <param name="card">The card to add</param>
        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        /// <summary>
        /// Method to get the next card from the deck
        /// </summary>
        /// <returns>The next card in the deck</returns>
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

        /// <summary>
        /// Method to remove a card from the deck at a specific index
        /// </summary>
        /// <param name="index">The index of the card to remove</param>
        public void RemoveCard(int index)
        {
            Cards.RemoveAt(index);
        }

        /// <summary>
        /// Method to shuffle the deck of cards
        /// </summary>
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