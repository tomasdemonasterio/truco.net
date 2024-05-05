using System.ComponentModel;
using GameNS;
using PlayerNS;

internal class Program
{
    private static void Main(string[] args){
        Game game = new Game(players: new List<Player>());
        game.AddPlayer(new Player("Player 1"));
        game.AddPlayer(new Player("Player 2"));
        game.AddPlayer(new Player("Player 3"));
        game.AddPlayer(new Player("Player 4"));
        game.Start();
    }
}