namespace SeaBattleConsole.SeaBattle.Model
{
    public class ShipVO
    {
        public int X { get; }
        public int Y { get; }
        public bool IsVertical { get; }
        public int Size { get; }

        public ShipVO(int x, int y, bool isVertical, int size)
        {
            X = x;
            Y = y;
            IsVertical = isVertical;
            Size = size;
        }
    }
}