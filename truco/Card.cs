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
        public Suits Suit { get; }
        public int Number { get; }
        public int Value { get; }
        public Card(Suits suit, int number)
        {
            Suit = suit;
            Number = number;
            Value = DetermineValue();
        }
        public int DetermineValue()
        {
            // asignar valor segun el truco
            int cardValue = 0;
            if (Number == 1)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 14;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 13;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 8;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 8;
                }
            }
            if (Number == 7)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 12;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 11;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 4;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 4;
                }
            }
            if (Number == 3)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 10;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 10;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 10;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 10;
                }
            }
            if (Number == 2)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 9;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 9;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 9;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 9;
                }
            }
            if (Number == 12)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 7;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 7;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 7;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 7;
                }
            }
            if (Number == 11)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 6;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 6;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 6;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 6;
                }
            }
            if (Number == 10)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 5;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 5;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 5;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 5;
                }
            }
            if (Number == 6)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 3;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 3;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 3;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 3;
                }
            }
            if (Number == 5)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 2;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 2;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 2;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 2;
                }
            }
            if (Number == 4)
            {
                if (Suit == Suits.Espadas)
                {
                    cardValue = 1;
                }
                if (Suit == Suits.Oros)
                {
                    cardValue = 1;
                }
                if (Suit == Suits.Copas)
                {
                    cardValue = 1;
                }
                if (Suit == Suits.Bastos)
                {
                    cardValue = 1;
                }
            }
            return cardValue;
        }
    }
}