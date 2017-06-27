using System;
using SeaBattleConsole.SeaBattle.Model;

namespace SeaBattleConsole.SeaBattle.Controllers
{
    public class UserController : IUserController
    {
        public enum State
        {
            Init,
            Lock,
            Unlock
        }
        
        private State _currentState = State.Init;

        public void Init()
        {
            _currentState = State.Unlock;
        }

        public void Lock()
        {
            _currentState = State.Lock;
        }

        public void Unlock()
        {
            ReadKey();
        }

        private void ReadKey()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            if (_currentState == State.Unlock)
            {
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("it's work");
                }
            }
        }
    }
}