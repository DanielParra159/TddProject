using Battle.Tests.Factories;
using NUnit.Framework;

namespace Battle.Tests
{
    public class HeroMovementTests
    {
        private Map _map;

        [SetUp]
        public void SetUp()
        {
            _map = MapFactory.AMap.Build();
        }

        [TestCase(Directions.Right, 5, 5, 6, 5)]
        [TestCase(Directions.Left, 2, 3, 1, 3)]
        [TestCase(Directions.Up, 3, 2, 3, 3)]
        [TestCase(Directions.Down, 3, 3, 3, 2)]
        public void WhenMove_ThenUpdateTheHeroPositionInTheMap(
            Directions direction, int initialPositionX, int initialPositionY,
            int expectedPositionX, int expectedPositionY)
        {
            var hero = new HeroSpawner().CreateHero(_map, initialPositionX, initialPositionY);
            var subjectUnderTest = new HeroMovement(hero, _map);
            subjectUnderTest.Move(direction);

            // Assert
            Assert.IsTrue(_map.ContainsAHero(expectedPositionX, expectedPositionY),
                          "The hero is not in the expected position");
        }

        [TestCase(Directions.Right, 5, 5, 6, 5)]
        [TestCase(Directions.Left, 2, 3, 1, 3)]
        [TestCase(Directions.Up, 3, 2, 3, 3)]
        [TestCase(Directions.Down, 3, 3, 3, 2)]
        public void WhenMove_ThenUpdateTheHeroPosition(
            Directions direction, int initialPositionX, int initialPositionY,
            int expectedPositionX, int expectedPositionY)
        {
            var hero = new HeroSpawner().CreateHero(_map, initialPositionX, initialPositionY);
            var subjectUnderTest = new HeroMovement(hero, _map);
            subjectUnderTest.Move(direction);

            // Assert
            Assert.AreEqual(expectedPositionX, hero.PositionX);
            Assert.AreEqual(expectedPositionY, hero.PositionY);
        }
    }
}
