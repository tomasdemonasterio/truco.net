public class Carta {
    private Palo palo {get; set;};
    private int numero {get; set;};

    public Carta(Palo palo, int numero) {
        this.palo = palo;
        this.numero = numero;
    }
}