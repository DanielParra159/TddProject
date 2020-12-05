using NUnit.Framework;

namespace Battle.Tests
{
    public class HeroTests
    {
        [TestCase(0,1)]
        [TestCase(7,4)]
        [TestCase(0,0)]
        public void WhenSetPosition_ThenSetIt(int expectedPositionX, int expectedPositionY)
        {
            var hero = new Hero();

            hero.SetPosition(expectedPositionX, expectedPositionY);
            
            Assert.AreEqual(expectedPositionX, hero.PositionX);
            Assert.AreEqual(expectedPositionY, hero.PositionY);
        }
        
    }
}
