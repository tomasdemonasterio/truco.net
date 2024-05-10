using PlayerNS;
using DeckNS;
using CardNS;
using RandomNS;

/// <summary>
/// The <c>RoundNS</c> namespace contains classes related to managing rounds in a card game.
/// </summary>
namespace RoundNS
{
    internal class Round
    {
        public List<Player> PlayersInRound { get; set; }
        private Deck Deck { get; }
        public int TrucoScore { get; set; }
        public int EnvidoScore { get; set; }
        private Dictionary<Card, Player> PlayedCards { get; set; }
        public Player? PlayerTurn { get; set; }
        public bool IsRoundEnded { get; set; }
        public bool EnvidoCantado { get; set; }
        public bool TrucoCantado { get; set; }


        public Round(List<Player> players)
        {
            PlayersInRound = players;
            Deck = new();
            TrucoScore = 1;
            EnvidoScore = 0;
            IsRoundEnded = false;
            PlayedCards = new Dictionary<Card, Player>();
            PlayerTurn = null;
            EnvidoCantado = false;
            TrucoCantado = false;
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
            foreach (Player player in PlayersInRound)
                {
                    player.PrepareForNewRound();
                }
            PlayerTurn = PlayersInRound[RandomHelper.GetRandomIndex(PlayersInRound.Count)];
            PlayerTurn.IsLastWinner = true;
            Deck.Shuffle();
            GiveCards();
            foreach (Player player in PlayersInRound)
            {
                player.Hand.CalculateEnvidoTotalValue();
            }
        }

        public void EndRound()
        {
            if (IsRoundEnded)
            {
                Player? trucoWinner = PlayersInRound.MaxBy(static p => p.PhasesWon);
                if (trucoWinner != null)
                {
                    trucoWinner.Score += TrucoScore;

                }
                Player? envidoWinner = WhoWonEnvido();
                if (envidoWinner != null)
                {
                    envidoWinner.Score += EnvidoScore;
                }
            }
        }

        public Player WhoWonEnvido()
        {
            int maxEnvidoValue = PlayersInRound.Max(static p => p.Hand.EnvidoTotalValue);
            List<Player> playersWithMaxEnvidoValue = PlayersInRound.Where(p => p.Hand.EnvidoTotalValue == maxEnvidoValue).ToList();
            return playersWithMaxEnvidoValue.Count > 1
                ?  null : playersWithMaxEnvidoValue[0];
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

        public void AccionCantada(Player player, Acciones Action, List<Acciones> acciones)
        {
            {
                if (Action == Acciones.Truco)
                {
                    TrucoCantado = true;
                }
                if (Action == Acciones.Envido)
                {
                    EnvidoCantado = true;
                }
                if (EnvidoCantado) 
                {
                    acciones.Remove(Acciones.Envido);
                }
                if (TrucoCantado) 
                {
                    acciones.Remove(Acciones.Truco);
                    acciones.Remove(Acciones.Envido);
                }
                player.LastAction = Action;
                RoundScoreCalculation();

                foreach (Player p in PlayersInRound)
                {
                    p.AvailableActions.Clear();
                    _ = p.AvailableActions.Add(Acciones.IrseAlMazo);
                    if (acciones.Contains(Acciones.Pasar) && !PlayedCards.Any(p2 => p2.Value == p))
                    {
                        _ = p.AvailableActions.Add(Acciones.Pasar);
                    }

                    foreach (Acciones accion in acciones)
                    {   
                        if (accion != Acciones.Pasar)
                        {
                            _ = p.AvailableActions.Add(accion);
                        }
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
            foreach (Player player in PlayersInRound)
            {
                if (!player.AvailableActions.Contains(Acciones.Pasar))
                {
                    _ = player.AvailableActions.Add(Acciones.Pasar);
                }
            }

            if (PlayersInRound.Any(static p => p.PhasesWon == 2))
            {
                IsRoundEnded = true;
            }

        }

        private void RoundScoreCalculation()
        {
            // Calcular puntos de la ronda
            if (PlayersInRound.Any(static p => p.LastAction == Acciones.Truco)
                && (PlayersInRound.Any(static p => p.LastAction == Acciones.QuieroTruco)
                || PlayersInRound.Any(static p => p.LastAction == Acciones.Retruco)))
            {
                TrucoScore = 2;
                return;
            }
            if (PlayersInRound.Any(static p => p.LastAction == Acciones.Retruco)
                && (PlayersInRound.Any(static p => p.LastAction == Acciones.QuieroTruco)
                || PlayersInRound.Any(static p => p.LastAction == Acciones.ValeCuatro)))
            {
                TrucoScore = 3;
                return;
            }
            if (PlayersInRound.Any(static p => p.LastAction == Acciones.ValeCuatro)
                && PlayersInRound.Any(static p => p.LastAction == Acciones.QuieroTruco))
            {
                TrucoScore = 4;
                return;
            }
            // Envido
            if (PlayersInRound.Any(static p => p.LastAction == Acciones.Envido)
                && (PlayersInRound.Any(static p => p.LastAction == Acciones.QuieroTruco)
                || PlayersInRound.Any(static p => p.LastAction == Acciones.RealEnvido)))
            {
                EnvidoScore = 2;
                return;
            }
            if (PlayersInRound.Any(static p => p.LastAction == Acciones.RealEnvido)
                && (PlayersInRound.Any(static p => p.LastAction == Acciones.QuieroTruco)
                || PlayersInRound.Any(static p => p.LastAction == Acciones.FaltaEnvido)))
            {
                EnvidoScore = 3;
                return;
            }
            if (PlayersInRound.Any(static p => p.LastAction == Acciones.FaltaEnvido)
                && PlayersInRound.Any(static p => p.LastAction == Acciones.QuieroTruco))
            {
                EnvidoScore = 30 - PlayersInRound.Max(static p => p.Score);
                return;
            }
        }

        public bool AllPlayersPlayedCard()
        {
            return PlayedCards.Count == PlayersInRound.Count;
        }
    }
}