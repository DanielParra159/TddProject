using System;
using UnityEngine.Assertions;

namespace Battle
{
    public class Map
    {
        private const int ColumnsDimension = 0;
        private const int RowsDimension = 1;
        public int NumberOfColumns => _cells.GetLength(ColumnsDimension);
        public int NumberOfRows => _cells.GetLength(RowsDimension);

        private readonly Hero[,] _cells;

        public Map(int width, int height)
        {
            _cells = new Hero[width, height];
        }

        public void AddHero(int positionX, int positionY, Hero hero)
        {
            Assert.IsTrue(positionX < NumberOfColumns, "PositionX must be smaller than number of columns");
            Assert.IsTrue(positionY < NumberOfRows, "PositionY must be smaller than number of rows");
            if (ContainsAHero(positionX, positionY))
            {
                throw new Exception($"There is a here in {positionX} {positionY}");
            }

            _cells[positionX, positionY] = hero;
        }

        public bool ContainsAHero(int positionX, int positionY)
        {
            return _cells[positionX, positionY] != null;
        }

        public void RemoveHero(int positionX, int positionY)
        {
            _cells[positionX, positionY] = null;
        }
    }
}
