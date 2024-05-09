namespace RoundNS {
    using PlayerNS;
    using DeckNS;
    using CardNS;
    using System.Security.Cryptography.X509Certificates;

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
        CardPlayed,
        Ended
    }
    class Round{
        public List<Player> playersInRound { get; set; }
        private Deck deck;
        public int roundScore { get; set;}

        public RoundState roundState { get; set;}

        private Dictionary<Card, Player> playedCards;

        public Player nextPlayer {get; set;}


        public Round(List<Player> players, Deck deck){
            playersInRound = players;
            this.deck = deck;
            roundScore = 0;
            roundState = RoundState.started;
            playedCards = new Dictionary<Card, Player>();
        }

        public void giveCards() {
            int i = 0;
            while (i < 3) {
                foreach (Player player in playersInRound) {
                    player.hand.AddCard(i, deck.getNextCard());
                }
                i++;
            }
        }
        
        public void playedCard(Player player, Card card){
            playedCards.Add(card, player);
            nextPlayer = playersInRound.Find(p => p.name != player.name);
        }

        public void endRound(){
            // Calcular puntos de la ronda
            if (roundState == RoundState.Ended){
                Player winner = playersInRound.MaxBy(p => p.phasesWon);
                winner.score += roundScore;
            }
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
                foreach (Player p in playersInRound){
                    p.availableActions.Clear();
                    if (acciones.Contains(Acciones.Pasar)) {
                        p.availableActions.Add(Acciones.Pasar);
                    }
                    if (p != player){
                        foreach (Acciones accion in acciones){
                            p.availableActions.Add(accion);
                        }
                        p.availableActions.Add(Acciones.IrseAlMazo);
                    }
                }
            }
        }

        public void playerSeFueAlMazo(Player player){
            // remover todas las cartas jugadas por el jugador y removerlo de la lista de jugadores
            playedCards = playedCards.Where(p => p.Value != player).ToDictionary(p => p.Key, p => p.Value);
            player.phasesWon = -1;
            //playersInRound.Remove(player);
        }

        public void winnerOfPhase(){
            Player winner = whoPlayedMostValuableCard();
            if (winner == null){
                return;
            }
            winner.phasesWon++;
            playedCards.Clear();
        }
    }
}