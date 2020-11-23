namespace Battle
{
    public class Map
    {
        private const int ColumnsDimension = 0;
        private const int RowsDimension = 1;
        public int NumberOfColumns => _cells.GetLength(ColumnsDimension);
        public int NumberOfRows => _cells.GetLength(RowsDimension);

        private readonly int[,] _cells;
        
        public Map(int width, int height)
        {
           _cells = new int[width, height];
        }
    }
}
