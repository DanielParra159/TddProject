using System;
using Battle.Entities;
using Battle.Tests.Factories;
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
            var map = MapFactory
                     .AMap
                     .WithHeight(height)
                     .WithWidth(width)
                     .Build();

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
            var map = MapFactory
                     .AMap
                     .WithHeight(10)
                     .WithWidth(10)
                     .Build();
            var hero = new Hero();

            Assert.IsFalse(map.ContainsAHero(heroPositionX, heroPositionY),
                           $"The map already contains a Hero in cell {heroPositionX},{heroPositionY} before add it");

            map.AddHero(heroPositionX, heroPositionY, hero);

            Assert.IsTrue(map.ContainsAHero(heroPositionX, heroPositionY),
                          $"The map does not contain a Hero in cell {heroPositionX},{heroPositionY}");
        }

        [Test]
        public void WhenAddANewHeroAndThereIsAlreadyAHeroInTheSameCell_ThenThrowAnException()
        {
            // Arrange
            var map = MapFactory
                     .AMap
                     .Build();
            var hero = new Hero();
            map.AddHero(5, 5, hero);
            var hero2 = new Hero();

            // Asserts
            Assert
               .Throws<Exception>(() =>
                                  {
                                      // Act
                                      map.AddHero(5, 5, hero2);
                                  }, "The map is not checking if there is already a hero");
        }

        [Test]
        public void WhenRemoveAHero_ThenRemoveItFromTheCells()
        {
            var map = MapFactory
                     .AMap
                     .Build();
            var hero = new Hero();
            map.AddHero(2, 3, hero);

            Assert.IsTrue(map.ContainsAHero(2, 3));
            map.RemoveHero(2, 3);

            Assert.IsFalse(map.ContainsAHero(2, 3));
        }
    }
}
