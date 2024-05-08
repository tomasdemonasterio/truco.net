namespace PlayerNS {
    using HandNS;
    using GameNS;

    enum PlayerState {
        isPlayingTruco,
        isPlayingEnvido,
        isPlayingRealEnvido,
        isPlayingRetruco,
        isPlayingValeCuatro,
        isPlayingFaltaEnvido,
        isPlayingIrseAlMazo,
        isPlayingQuiero,
        isPlayingPasar,
        isPlayingStart
    }

    enum Acciones {
        Truco,
        Envido,
        RealEnvido,
        Retruco,
        ValeCuatro,
        FaltaEnvido,
        IrseAlMazo,
        Quiero,
        Pasar}

    class Player {
       
        private Game game;
        public string name { get;}
        public Hand hand { get;}
        public int score { get; set; }
        public bool isFirstWinner { get; set; }
        public PlayerState playerState { get; set; }
        public int phasesWon { get; set; }
        public HashSet<Acciones> availableActions { get; set; }

        public Player(string name, Game game) {
            this.name = name;
            this.game = game;
            hand = new Hand();
            score = 0;
            isFirstWinner = false;
            playerState = PlayerState.isPlayingStart;
            phasesWon = 0;
            availableActions = new HashSet<Acciones>() { Acciones.Truco, Acciones.Envido, Acciones.Pasar, Acciones.IrseAlMazo };
        }

        public void playCard(int index) {
            // Play card
            game.round.playedCard(this, hand.GetCard(index));
            hand.removeCard(index);
        }

        public string playerAvailableActionsToString() {
            string actions = "";
            foreach (Acciones action in availableActions) {
                actions += action.ToString() + " ";
            }
            return actions;
        }
        
    }
}