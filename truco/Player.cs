using HandNS;
using GameNS;

namespace PlayerNS
{
    /// <summary>
    /// Enumeration representing the actions a player can take in the game.
    /// </summary>
    internal enum Acciones
    {
        Truco,
        Envido,
        RealEnvido,
        Retruco,
        ValeCuatro,
        FaltaEnvido,
        IrseAlMazo,
        QuieroEnvido,
        QuieroTruco,
        NoQuiero,
        Pasar
    }

    /// <summary>
    /// Class representing a player in a game. It contains properties and methods related to the player's actions, score, and status in the game.
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// The game the player is participating in
        /// </summary>
        private Game Game { get; }

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The hand of cards the player has
        /// </summary>
        public Hand Hand { get; set; }

        /// <summary>
        /// The score of the player
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Whether the player was the last winner
        /// </summary>
        public bool IsLastWinner { get; set; }

        /// <summary>
        /// The number of phases the player has won
        /// </summary>
        public int PhasesWon { get; set; }

        /// <summary>
        /// The actions available to the player
        /// </summary>
        public HashSet<Acciones> AvailableActions { get; set; }

        /// <summary>
        /// The last action the player took
        /// </summary>
        public Acciones LastAction { get; set; }

        /// <summary>
        /// Constructor for the Player class
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="game">The game the player is participating in</param>
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

        /// <summary>
        /// Method for the player to play a card
        /// </summary>
        /// <param name="index">The index of the card to play</param>
        public void PlayCard(int index)
        {
            Game.Round?.PlayedCard(this, Hand.GetCard(index));
            Hand.RemoveCard(index);
        }

        /// <summary>
        /// Method to get a string representation of the player's available actions
        /// </summary>
        /// <returns>A string representing the player's available actions</returns>
        public string PlayerAvailableActionsToString()
        {
            string actions = "";
            foreach (Acciones action in AvailableActions)
            {
                actions += action.ToString() + " ";
            }
            return actions;
        }

        public void PrepareForNewRound() {
            PhasesWon = 0;
            LastAction = Acciones.Pasar;
            Hand = new Hand();
            AvailableActions = new HashSet<Acciones>() { Acciones.Truco, Acciones.Envido, Acciones.Pasar, Acciones.IrseAlMazo };
        }
    }
}