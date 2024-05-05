namespace PlayerNS {
    using CardNS;
    using DeckNS;
    using HandNS;

    class Player {
        private string name;
        private Hand hand;
        private int score;
        private bool playerShowedCards;
        

        public Player(string name) {
            this.name = name;
            this.hand = new Hand();
            this.score = 0;
            this.playerShowedCards = false;
        }

        public string GetName() {
            return this.name;
        }

        public Hand GetHand() {
            return this.hand;
        }

        public int GetScore() {
            return this.score;
        }


        public void SetScore(int score) {
            this.score = score;
        }

        public void SetHand(Hand hand) {
            this.hand = hand;
        }

        public void truco() {
            // Truco
        }

        public void quiero() {
            // Quiero
        }

        public void retruco() {
            // Retruco
        }

        public void valeCuatro() {
            // Vale Cuatro
        }

        public void envido() {
            // Envido
        }

        public void realEnvido() {
            // Real Envido
        }

        public void faltaEnvido() {
            // Falta Envido
        }

        public void pasar(Card card) {
            // Pasar
            hand.removeCard(card);
        }

        public void irAlMazo() {
            // Ir al mazo
        }

    }
}