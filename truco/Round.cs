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
        
        public void givePoints(){
            
        }
        public void playedCard(Player player, Card card){
            playedCards.Add(card, player);
            nextPlayer = playersInRound.Find(p => p.name != player.name);
        }

        public void endRound(){
            List<Player> players = playersInRound.FindAll(p => p.playerState != PlayerState.isPlayingIrseAlMazo);
            // Calcular puntos
            if (roundState == RoundState.Truco){
                roundScore = 2;
                Player winner = whoPlayedMostValuableCard();
                winner.score += roundScore;
            } 
            if (roundState == RoundState.Retruco){
                roundScore = 3;
                Player winner = playedCards.Values.First();
                winner.score += roundScore;
            } 
            if (roundState == RoundState.ValeCuatro){
                roundScore = 4;
                Player winner = playedCards.Values.First();
                winner.score += roundScore;
            } 
            if (roundState == RoundState.Envido){
                roundScore = 2;
            } 
            if (roundState == RoundState.RealEnvido){
                roundScore = 3;
            } else {
                roundScore = 1;
            }
            if (roundState == RoundState.IrseAlMazo){
                roundScore = 1;
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
                foreach (Player p in playersInRound){
                    p.availableActions.Clear();
                    p.availableActions.Add(Acciones.Pasar);
                    p.availableActions.Add(Acciones.IrseAlMazo);
                    if (p != player){
                        foreach (Acciones accion in acciones){
                            p.availableActions.Add(accion);
                        }
                    }
                }
            }
        }

        public void playerSeFueAlMazo(Player player){
            // remover todas las cartas jugadas por el jugador y removerlo de la lista de jugadores
            playedCards = playedCards.Where(p => p.Value != player).ToDictionary(p => p.Key, p => p.Value);
            playersInRound.Remove(player);
        }
    }
}