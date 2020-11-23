using NUnit.Framework;

namespace Battle.Tests
{
    public class MapTests
    {
        [TestCase(2, 3)]
        [TestCase(5,5)]
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
    }
}
