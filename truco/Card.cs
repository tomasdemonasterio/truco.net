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
            value = determineValue();
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

        public int determineValue()
        {
            // asignar valor segun el truco
            int cardValue = 0;
            if (number == 1) {
                if (suit == Suits.Espadas) {
                    cardValue = 14;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 13;
                }
                if (suit == Suits.Copas) {
                    cardValue = 8;
                }
                if (suit == Suits.Oros) {
                    cardValue = 8;
                }
            }
            if (number == 7) {
                if (suit == Suits.Espadas) {
                    cardValue = 12;
                }
                if (suit == Suits.Oros) {
                    cardValue = 11;
                }
                if (suit == Suits.Copas) {
                    cardValue = 4;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 4;
                }
            }
            if (number == 3) {
                if (suit == Suits.Espadas) {
                    cardValue = 10;
                }
                if (suit == Suits.Oros) {
                    cardValue = 10;
                }
                if (suit == Suits.Copas) {
                    cardValue = 10;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 10;
                }
            }
            if (number == 2) {
                if (suit == Suits.Espadas) {
                    cardValue = 9;
                }
                if (suit == Suits.Oros) {
                    cardValue = 9;
                }
                if (suit == Suits.Copas) {
                    cardValue = 9;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 9;
                }
            }
            if (number == 12) {
                if (suit == Suits.Espadas) {
                    cardValue = 7;
                }
                if (suit == Suits.Oros) {
                    cardValue = 7;
                }
                if (suit == Suits.Copas) {
                    cardValue = 7;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 7;
                }
            }
            if (number == 11) {
                if (suit == Suits.Espadas) {
                    cardValue = 6;
                }
                if (suit == Suits.Oros) {
                    cardValue = 6;
                }
                if (suit == Suits.Copas) {
                    cardValue = 6;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 6;
                }
            }
            if (number == 10) {
                if (suit == Suits.Espadas) {
                    cardValue = 5;
                }
                if (suit == Suits.Oros) {
                    cardValue = 5;
                }
                if (suit == Suits.Copas) {
                    cardValue = 5;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 5;
                }
            }
            if (number == 6) {
                if (suit == Suits.Espadas) {
                    cardValue = 3;
                }
                if (suit == Suits.Oros) {
                    cardValue = 3;
                }
                if (suit == Suits.Copas) {
                    cardValue = 3;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 3;
                }
            }
            if (number == 5) {
                if (suit == Suits.Espadas) {
                    cardValue = 2;
                }
                if (suit == Suits.Oros) {
                    cardValue = 2;
                }
                if (suit == Suits.Copas) {
                    cardValue = 2;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 2;
                }
            }
            if (number == 4) {
                if (suit == Suits.Espadas) {
                    cardValue = 1;
                }
                if (suit == Suits.Oros) {
                    cardValue = 1;
                }
                if (suit == Suits.Copas) {
                    cardValue = 1;
                }
                if (suit == Suits.Bastos) {
                    cardValue = 1;
                }
            }
            return cardValue;
        }
    }
}