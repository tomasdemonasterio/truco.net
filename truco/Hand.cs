using CardNS;

namespace HandNS
{
    internal class Hand
    {
        public Dictionary<int, Card> Cards { get; }

        public Hand()
        {
            Cards = new Dictionary<int, Card>();
        }

        public void AddCard(int index, Card card)
        {
            Cards.Add(index, card);
        }

        public void RemoveCard(int index)
        {
            _ = Cards.Remove(index);
        }
        public Card GetCard(int index)
        {
            return Cards[index];
        }

        public override string ToString()
        {
            string result = "";
            foreach (KeyValuePair<int, Card> entry in Cards)
            {
                result += entry.Key + ". " + entry.Value.Suit + " " + entry.Value.Number + " Valor: " + entry.Value.Value + "\n";
            }
            if (result == "")
            {
                result = "Empty hand";
            }
            return result;
        }
    }
}