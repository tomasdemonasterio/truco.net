namespace RoundNS {
    using PlayerNS;
    using DeckNS;
    using CardNS;

    enum RoundState {
        started,
        Truco,
        Retruco,
        ValeCuatro,
        Envido,
        RealEnvido,
        FaltaEnvido,
        FaltaTruco,
        Quiero,
        IrseAlMazo,
        Ended
    }
    class Round{
        private List<Player> players;
        private Deck deck;
        public int roundScore { get; set;}

        public RoundState roundState { get; set;}

        private Dictionary<Card, Player> playedCards;

        public Player nextPlayer {get; set;}


        public Round(List<Player> players, Deck deck){
            this.players = players;
            this.deck = deck;
            roundScore = 0;
            roundState = RoundState.started;
            playedCards = new Dictionary<Card, Player>();
        }

        public void giveCards() {
            int i = 0;
            while (i < 3) {
                foreach (Player player in players) {
                    player.hand.AddCard(i, deck.getNextCard());
                }
                i++;
            }
        }
        
        public void givePoints(){
            
        }
        public void playedCard(Player player, Card card){
            playedCards.Add(card, player);
            nextPlayer = players.Find(p => p.name != player.name);
        }

        public void endRound(){
            // Calcular puntos
            if (roundState == RoundState.Truco){
                roundScore = 2;
            } 
            if (roundState == RoundState.Retruco){
                roundScore = 3;
            } 
            if (roundState == RoundState.ValeCuatro){
                roundScore = 4;
            } 
            if (roundState == RoundState.Envido){
                roundScore = 2;
            } 
            if (roundState == RoundState.RealEnvido){
                roundScore = 3;
            } else {
                roundScore = 1;
            }
            // Calcular ganador
            if (roundState == RoundState.Truco || roundState == RoundState.Retruco || roundState == RoundState.ValeCuatro){
                Player winner = playedCards.Values.First();
                winner.score += roundScore;
            }
            roundState = RoundState.Ended;
        }

        public Player whoPlayedMostValuableCard(){
            // El ganador es el que puso la carta mas valiosa
            int maxPlayedCard = 0;
            Player winner = null;
            foreach (KeyValuePair<Card, Player> playedCard in playedCards){
                if (playedCard.Key.getValue() > maxPlayedCard){
                    maxPlayedCard = playedCard.Key.getValue();
                    winner = playedCard.Value;
                } else if (playedCard.Key.getValue() == maxPlayedCard){
                    winner = null;
                }
            }
            return winner;
         }

         public Player getNextPlayer(){
             nextPlayer = whoPlayedMostValuableCard() ?? nextPlayer;
             return nextPlayer;
         }
            
            public void accionCantada(Player player, List<Acciones> acciones, RoundState roundState){ {
                this.roundState = roundState;
                foreach (Player p in players){
                    p.availableActions.Clear();
                    if (p != player){
                        foreach (Acciones accion in acciones){
                            p.availableActions.Add(accion);
                        }
                    }
                }
            }
        }
    }
}