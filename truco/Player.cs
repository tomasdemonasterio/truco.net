namespace PlayerNS {
    using HandNS;
    using GameNS;

    class Player {
        private string name;
        private Hand hand;
        private int score;
        private bool playerShowedCards;
        private Game game;
        

        public Player(string name, Game game) {
            this.name = name;
            this.hand = new Hand();
            this.score = 0;
            this.playerShowedCards = false;
            this.game = game;
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
            if (playerShowedCards) {
                game.round.roundScore = 2;
            }
            game.round.roundScore = 1;
            game.round.roundState = RoundNS.RoundState.Truco;
        }

        public void quiero() {
            // Quiero
            game.round.roundScore = 2;
            game.round.roundState = RoundNS.RoundState.Quiero;
        }

        public void retruco() {
            // Retruco
            game.round.roundScore = 3;
            game.round.roundState = RoundNS.RoundState.Retruco;
        }

        public void valeCuatro() {
            // Vale Cuatro
            game.round.roundScore = 4;
            game.round.roundState = RoundNS.RoundState.ValeCuatro;
        }

        public void envido() {
            // Envido
            game.round.roundState = RoundNS.RoundState.Envido;
        }

        public void realEnvido() {
            // Real Envido
            game.round.roundState = RoundNS.RoundState.RealEnvido;
        }

        public void faltaEnvido() {
            // Falta Envido
            game.round.roundState = RoundNS.RoundState.FaltaEnvido;
        }

        public void pasar(int index) {
            // Pasar
            hand.removeCard(index);
        }

        public void irseAlMazo() {
            // Ir al mazo
        }

        public void faltaTruco() {
            // Falta Truco
            game.round.roundState = RoundNS.RoundState.FaltaTruco;
        }

    }
}