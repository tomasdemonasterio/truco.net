using HandNS;
using GameNS;

namespace PlayerNS
{
    internal enum Acciones
    {
        Truco,
        Envido,
        RealEnvido,
        Retruco,
        ValeCuatro,
        FaltaEnvido,
        IrseAlMazo,
        Quiero,
        Pasar
    }

    internal class Player
    {
        private Game Game { get; }
        public string Name { get; }
        public Hand Hand { get; }
        public int Score { get; set; }
        public bool IsLastWinner { get; set; }
        public int PhasesWon { get; set; }
        public HashSet<Acciones> AvailableActions { get; set; }
        public Acciones LastAction { get; set; }

        public Player(string name, Game game)
        {
            Name = name;
            Game = game;
            Hand = new Hand();
            Score = 0;
            IsLastWinner = false;
            PhasesWon = 0;
            AvailableActions = new HashSet<Acciones>() { Acciones.Truco, Acciones.Envido, Acciones.Pasar, Acciones.IrseAlMazo };
            LastAction = Acciones.Pasar;
        }

        public void PlayCard(int index)
        {
            Game.Round?.PlayedCard(this, Hand.GetCard(index));
            Hand.RemoveCard(index);
        }

        public string PlayerAvailableActionsToString()
        {
            string actions = "";
            foreach (Acciones action in AvailableActions)
            {
                actions += action.ToString() + " ";
            }
            return actions;
        }

    }
}