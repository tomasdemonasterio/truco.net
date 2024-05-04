namespace Carta
{
    public enum Palo
    {
        Espadas,
        Bastos,
        Copas,
        Oros
    }

    public class Carta
    {
        private Palo palo;
        private int numero;
        public Carta(Palo palo, int numero)
        {
            this.palo = palo;
            this.numero = numero;
        }

        public int getNumero()
        {
            return numero;
        }

        public Palo getPalo()
        {
            return palo;
        }
    }
}