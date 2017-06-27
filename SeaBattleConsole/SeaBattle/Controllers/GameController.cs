using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using SeaBattleConsole.SeaBattle.Model;
using SeaBattleConsole.SeaBattle.View;

namespace SeaBattleConsole.SeaBattle.Controllers
{
    public class GameController
    {
        public enum State {Init, Start, WaitUser, End};

        private BattleFieldVO _battleFiledVo;
        private GameView _gameView;
        private State _currentState = State.Init;

        public void Init(IUserController userFirst, IUserController userSecond)
        {
            _battleFiledVo = new BattleFieldVO();
            CreateFields(userFirst, userSecond);
            
            _gameView = new GameView();
            _gameView.Init();
            
            _currentState = State.Start;

            userFirst.Lock();
            userSecond.Lock();
            ReadKey();
        }

        private void CreateFields(IUserController userFirst, IUserController userSecond)
        {
            _battleFiledVo.Fields = new List<Field>();
            _battleFiledVo.Fields.Add(new Field(userFirst));
            _battleFiledVo.Fields.Add(new Field(userSecond));
        }

        public void GenerateShipsAllUsers()
        {
            for (int i = 0; i < _battleFiledVo.Fields.Count; i++)
            {
                Field field = _battleFiledVo.Fields[i];
                field.Ships.Add(new ShipVO(0, 0, true, 1));
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
                    _battleFiledVo.Fields[0].User.Unlock();
                }
            }
        }
    }
}