using System;
using SeaBattleConsole.SeaBattle;

namespace SeaBattleConsole
{
    internal class Program
    {
        private static GameSeaBattle _game;
        
        public static void Main(string[] args)
        {
            _game = new GameSeaBattle();
            _game.Start();
        }
    }
}