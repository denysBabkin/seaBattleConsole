using System;
using SeaBattleConsole.SeaBattle.Controllers;

namespace SeaBattleConsole.SeaBattle
{
    public class GameSeaBattle
    {
        private GameController _gameController;
        
        public void Start()
        {
            _gameController = new GameController();
            _gameController.Init();
        }
    }
}