namespace CardNS
{
    public enum Suits
    {
        Espadas,
        Bastos,
        Copas,
        Oros
    }

    public class Card
    {
        private Suits suit;
        private int number;
        private int value;
        public Card(Suits suit, int number)
        {
            this.suit = suit;
            this.number = number;     
        }

        public int getValue()
        {
            return value;
        }

        public Suits getSuit()
        {
            return suit;
        }

        public int getNumber()
        {
            return number;
        }
    }
}