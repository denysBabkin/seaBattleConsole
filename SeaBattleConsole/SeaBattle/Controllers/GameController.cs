using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using SeaBattleConsole.SeaBattle.Model;
using SeaBattleConsole.SeaBattle.View;

namespace SeaBattleConsole.SeaBattle.Controllers
{
    public class GameController
    {
        public const int MaxUserCount = 2;

        public enum State {Init, Start, WaitUser, End};

        private BattleFieldVO _battleFiledVo;
        private GameView _gameView;
        private State _currentState = State.Init;

        public void Init()
        {
            _battleFiledVo = new BattleFieldVO();
            CreateFields();
            
            _gameView = new GameView();
            _gameView.Init();
            
            _currentState = State.Start;

            ReadKey();
        }

        private void CreateFields()
        {
            _battleFiledVo.Fields = new List<Field>();
            for (int i = 0; i < MaxUserCount; i++)
            {
                _battleFiledVo.Fields.Add(new Field(i.ToString()));
            }
        }

        public void GenerateShipsAllUsers()
        {
            for (int i = 0; i < _battleFiledVo.Fields.Count; i++)
            {
                Field field = _battleFiledVo.Fields[i];
                field.Ships[0] = new ShipVO(0, 0, true, 1);
            }
        }

        private void ReadKey()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            if (_currentState == State.Start)
            {
                if (cki.Key == ConsoleKey.Enter)
                {
                    GenerateShipsAllUsers();
                    _gameView.Start();
                }
            }
            else if(_currentState == State.WaitUser)
            {
                
            }
            
            ReadKey();
        }
    }
}