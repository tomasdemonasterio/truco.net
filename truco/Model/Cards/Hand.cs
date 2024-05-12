using CardNS;

namespace HandNS
{
    /// <summary>
    /// Class representing a hand of cards
    /// </summary>
    internal class Hand
    {
        /// <summary>
        /// Dictionary of cards in the hand, with the key being the index of the card
        /// </summary>
        public Dictionary<int, Card> Cards { get; }
        public int EnvidoTotalValue { get; set; }

        /// <summary>
        /// Constructor for the Hand class
        /// </summary>
        public Hand()
        {
            Cards = new Dictionary<int, Card>();
            EnvidoTotalValue = 0;
        }

        /// <summary>
        /// Method to add a card to the hand at a specific index
        /// </summary>
        /// <param name="index">The index at which to add the card</param>
        /// <param name="card">The card to add</param>
        public void AddCard(int index, Card card)
        {
            if (Cards.Count < 3)
            {
                Cards.Add(index, card);
            }
            
        }

        /// <summary>
        /// Method to remove a card from the hand at a specific index
        /// </summary>
        /// <param name="index">The index of the card to remove</param>
        public void RemoveCard(int index)
        {
            _ = Cards.Remove(index);
        }

        /// <summary>
        /// Method to get a card from the hand at a specific index
        /// </summary>
        /// <param name="index">The index of the card to get</param>
        /// <returns>The card at the specified index</returns>
        public Card GetCard(int index)
        {
            return Cards[index];
        }

        /// <summary>
        /// Method to get a string representation of the hand
        /// </summary>
        /// <returns>A string representing the hand</returns>
        public override string ToString()
        {
            string result = "";
            foreach (KeyValuePair<int, Card> entry in Cards)
            {
                result += entry.Key + ". " + entry.Value.ToString();
            }
            if (result == "")
            {
                result = "Empty hand";
            }
            return result;
        }

        public void CalculateEnvidoTotalValue()
        {
            // sumar dos cartas del mismo palo
            foreach (KeyValuePair<int, Card> entry in Cards)
            {
                foreach (KeyValuePair<int, Card> entry2 in Cards)
                {
                    if (entry.Value.Suit == entry2.Value.Suit && entry.Key != entry2.Key)
                    {
                        EnvidoTotalValue += 20;
                        EnvidoTotalValue += (entry.Value.Number <= 7) ? entry.Value.Number: 0;
                        EnvidoTotalValue += (entry2.Value.Number <= 7) ? entry2.Value.Number : 0;
                        return;
                    }
                }
            } 
        }
    }
}