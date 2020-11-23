using NUnit.Framework;

namespace Battle.Tests
{
    public class MapTests
    {
        [TestCase(2, 3)]
        [TestCase(5, 5)]
        public void WhenCreateAMapWithWidthAndHeight_ThenCreateAMapWithTheCorrectNumberOfRowsAndColumns(
            int width, int height)
        {
            // Act
            var map = new Map(width, height);

            // Assert
            Assert.AreEqual(width, map.NumberOfColumns,
                            $"Number of columns {map.NumberOfColumns} is different than the width {width}");
            Assert.AreEqual(height, map.NumberOfRows,
                            $"Number of rows {map.NumberOfRows} is different than the height {height}");
        }

        [TestCase(0, 0)]
        [TestCase(9, 9)]
        [TestCase(2, 5)]
        public void WhenAddANewHero_StoreItInTheCorrectCell(int heroPositionX, int heroPositionY)
        {
            var map = new Map(10, 10);
            var hero = new Hero();

            Assert.IsFalse(map.ContainsAHero(heroPositionX, heroPositionY),
                           $"The map already contains a Hero in cell {heroPositionX},{heroPositionY} before add it");

            map.AddHero(heroPositionX, heroPositionY, hero);

            Assert.IsTrue(map.ContainsAHero(heroPositionX, heroPositionY),
                          $"The map does not contain a Hero in cell {heroPositionX},{heroPositionY}");
        }
    }
}
