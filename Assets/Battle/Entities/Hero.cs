namespace Battle.Entities
{
    public class Hero
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public void SetPosition(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
