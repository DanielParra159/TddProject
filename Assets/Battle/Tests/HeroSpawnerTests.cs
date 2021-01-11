using Battle.Tests.Factories;
using Battle.UseCases;
using NUnit.Framework;

namespace Battle.Tests
{
    public class HeroSpawnerTests
    {
        [Test]
        public void WhenCreateAHero_ThenSaveTheHeroInTheMap()
        {
            var map = MapFactory.AMap.Build();
            var subjectUnderTest = new HeroSpawner();
            const int positionX = 5;
            const int positionY = 5;
            subjectUnderTest.CreateHero(map, positionX, positionY);

            Assert.IsTrue(map.ContainsAHero(positionX, positionY));
        }

        [Test]
        public void WhenCreateAHeroInTheMap_ThenTheHeroPositionIsCorrect()
        {
            var map = MapFactory.AMap.Build();
            var subjectUnderTest = new HeroSpawner();
            const int positionX = 5;
            const int positionY = 5;
            
            var hero = subjectUnderTest.CreateHero(map, positionX, positionY);

            Assert.AreEqual(positionX, hero.PositionX);
            Assert.AreEqual(positionY, hero.PositionY);
        }
    }
}
