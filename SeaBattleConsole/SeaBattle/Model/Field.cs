using System;
using System.Collections.Generic;
using SeaBattleConsole.SeaBattle.Controllers;

namespace SeaBattleConsole.SeaBattle.Model
{
    public class Field
    {
        public Field(string id)
        {
            Id = id;
        }
        
        public string Id { get; }
        
        public List<ShipVO> Ships = new List<ShipVO>();

        public IController Controller;
    }

    public interface IController
    {
        void Init();
        void Lock();
        void Unlock();
    }

    public class UserController : IController
    {
        public void Init()
        {
            
        }

        public void Lock()
        {
            
        }

        public void Unlock()
        {
            ReadKey();
        }

        private void ReadKey()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            if (_currentState == GameController.State.Start)
            {
                if (cki.Key == ConsoleKey.Enter)
                {
                    GenerateShipsAllUsers();
                    _gameView.Start();
                }
            }
        }
    }
}