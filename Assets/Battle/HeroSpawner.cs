using Battle.Entities;

namespace Battle
{
    public class HeroSpawner
    {
        public Hero CreateHero(Map map, int positionX, int positionY)
        {
            var hero = new Hero();
            map.AddHero(positionX, positionY, hero);
            hero.SetPosition(positionX, positionY);
            return hero;
        }
    }
}
