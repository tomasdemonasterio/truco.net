namespace CardNS
{
    /// <summary>
    /// Enumeration for the four possible suits of a card
    /// </summary>
    public enum Suits
    {
        Espadas,
        Bastos,
        Copas,
        Oros
    }

    /// <summary>
    /// Class representing a playing card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Property representing the suit of the card
        /// </summary>
        public Suits Suit { get; }

        /// <summary>
        /// Property representing the number of the card
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Property representing the value of the card in the game of Truco
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Constructor for the Card class
        /// </summary>
        /// <param name="suit">The suit of the card</param>
        /// <param name="number">The number of the card</param>
        public Card(Suits suit, int number)
        {
            Suit = suit;
            Number = number;
            Value = DetermineValue();
        }

        public override string ToString()
        {
            return Suit + " " + Number + " Valor: " + Value + "\n";
        }

        /// <summary>
        /// Method to determine the value of the card based on its number and suit
        /// </summary>
        /// <returns>The value of the card according to the rules of Truco</returns>
        public int DetermineValue()
        {
            // Assign value according to the rules of Truco
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