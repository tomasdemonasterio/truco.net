using System.ComponentModel;
using Carta;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<Carta.Carta> cartas = new HashSet<Carta.Carta>();

        for(int i = 1; i < 8; i++)
        {
            cartas.Add(new Carta.Carta(Palo.Espadas, i));
            cartas.Add(new Carta.Carta(Palo.Bastos, i));
            cartas.Add(new Carta.Carta(Palo.Copas, i));
            cartas.Add(new Carta.Carta(Palo.Oros, i));
        }

        cartas.Add(new Carta.Carta(Palo.Espadas, 10));
        cartas.Add(new Carta.Carta(Palo.Bastos, 10));
        cartas.Add(new Carta.Carta(Palo.Copas, 10));
        cartas.Add(new Carta.Carta(Palo.Oros, 10));


        foreach (Carta.Carta cartaItem in cartas)
        {
            Console.WriteLine(cartaItem.getNumero() + " de " + cartaItem.getPalo());
        }

        Console.WriteLine("Cantidad de cartas: " + cartas.Count);
    }
}