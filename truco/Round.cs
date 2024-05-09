using PlayerNS;
using DeckNS;
using CardNS;
using RandomNS;

namespace RoundNS
{
    internal class Round
    {
        public List<Player> PlayersInRound { get; set; }
        private Deck Deck { get; }
        public int RoundScore { get; set; }

        private Dictionary<Card, Player> PlayedCards { get; set; }

        public Player? PlayerTurn { get; set; }

        public bool IsRoundEnded { get; set; }


        public Round(List<Player> players)
        {
            PlayersInRound = players;
            Deck = new();
            RoundScore = 1;
            IsRoundEnded = false;
            PlayedCards = new Dictionary<Card, Player>();
            PlayerTurn = null;
        }

        public void GiveCards()
        {
            int i = 0;
            while (i < 3)
            {
                foreach (Player player in PlayersInRound)
                {
                    player.Hand.AddCard(i, Deck.GetNextCard());
                }
                i++;
            }
        }

        public void PlayedCard(Player player, Card card)
        {
            PlayedCards.Add(card, player);
            PlayerTurn = PlayersInRound.Find(p => p.Name != player.Name);
        }

        public void StartRound()
        {
            // Iniciar la ronda
            PlayerTurn = PlayersInRound[RandomHelper.GetRandomIndex(PlayersInRound.Count)];
            PlayerTurn.IsLastWinner = true;
            Deck.Shuffle();
            GiveCards();
        }

        public void EndRound()
        {
            if (IsRoundEnded)
            {
                Player? winner = PlayersInRound.MaxBy(static p => p.PhasesWon);
                if (winner != null)
                {
                    winner.Score += RoundScore;
                }
                foreach (Player player in PlayersInRound)
                {
                    player.PhasesWon = 0;
                    player.LastAction = Acciones.Pasar;
                    player.Hand.Cards.Clear();
                    player.AvailableActions = new HashSet<Acciones>() { Acciones.Truco, Acciones.Envido, Acciones.Pasar, Acciones.IrseAlMazo };
                }
            }
        }

        public Player WhoPlayedMostValuableCard()
        {
            // El ganador es el que puso la carta mas valiosa
            // si hay empate gana el anterior ganador de la fase o el que jugo primero si es la primera fase
            int maxCardValue = PlayedCards.MaxBy(static p => p.Key.Value).Key.Value;
            List<Player> playersWithMaxCardValue = PlayedCards.Where(p => p.Key.Value == maxCardValue).Select(p => p.Value).ToList();

            return playersWithMaxCardValue.Count > 1
                ? playersWithMaxCardValue[0].IsLastWinner ? playersWithMaxCardValue[0] : playersWithMaxCardValue[1]
                : playersWithMaxCardValue[0];
        }

        public void AccionCantada(Player player, Acciones Action, List<Acciones> acciones/*, RoundState roundState*/)
        {
            {
                player.LastAction = Action;
                RoundScoreCalculation();
                foreach (Player p in PlayersInRound)
                {
                    p.AvailableActions.Clear();
                    if (acciones.Contains(Acciones.Pasar))
                    {
                        _ = p.AvailableActions.Add(Acciones.Pasar);
                        _ = p.AvailableActions.Add(Acciones.IrseAlMazo);
                    }
                    if (p != player)
                    {
                        foreach (Acciones accion in acciones)
                        {
                            _ = p.AvailableActions.Add(accion);
                        }
                        _ = p.AvailableActions.Add(Acciones.IrseAlMazo);
                    }
                }
            }
        }

        public void PlayerSeFueAlMazo(Player player)
        {
            // remover todas las cartas jugadas por el jugador y removerlo de la lista de jugadores
            PlayedCards = PlayedCards.Where(p => p.Value != player).ToDictionary(p => p.Key, p => p.Value);
            player.PhasesWon = -1;
            player.LastAction = Acciones.IrseAlMazo;
        }

        public void WinnerOfPhase()
        {
            Player winner = WhoPlayedMostValuableCard();
            if (winner == null)
            {
                return;
            }
            winner.PhasesWon++;
            PlayedCards.Clear();
            PlayerTurn = winner;

            if (PlayersInRound.Any(static p => p.PhasesWon == 2))
            {
                IsRoundEnded = true;
            }

        }

        private void RoundScoreCalculation()
        {
            // Calcular puntos de la ronda
            if (PlayersInRound.Any(static p => p.LastAction is Acciones.Truco or Acciones.Retruco))
            {
                if (PlayersInRound.Any(static p => p.LastAction == Acciones.Quiero))
                {
                    RoundScore = PlayersInRound.Any(static p => p.LastAction == Acciones.Retruco) ? 3 : 2;
                    return;
                }
            }

            if (PlayersInRound.Any(static p => p.LastAction is Acciones.ValeCuatro or Acciones.IrseAlMazo))
            {
                if (PlayersInRound.Any(static p => p.LastAction == Acciones.Quiero))
                {
                    RoundScore = 4;
                    return;
                }
                if (PlayersInRound.Any(static p => p.LastAction == Acciones.Retruco))
                {
                    RoundScore = 3;
                    return;
                }
            }

            if (PlayersInRound.Any(static p => p.LastAction is Acciones.Envido or Acciones.RealEnvido))
            {
                RoundScore = 99;
                return;
            }
            if (PlayersInRound.Any(static p => p.LastAction == Acciones.FaltaEnvido))
            {
                RoundScore = PlayersInRound.Any(static p => p.LastAction == Acciones.Quiero) ? 99 : RoundScore;
                return;
            }
        }


        public bool AllPlayersPlayedCard()
        {
            return PlayedCards.Count == PlayersInRound.Count;
        }
    }
}