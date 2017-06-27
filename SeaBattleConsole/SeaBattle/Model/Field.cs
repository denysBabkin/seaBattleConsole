using System.Collections.Generic;
using SeaBattleConsole.SeaBattle.Controllers;

namespace SeaBattleConsole.SeaBattle.Model
{
    public class Field
    {

        public Field(IUserController user)
        {
            User = user;
        }
        
        public IUserController User { get; }
        
        public List<ShipVO> Ships = new List<ShipVO>();
    }
}