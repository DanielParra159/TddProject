using System;

namespace Battle
{
    public class HeroMovement : IHeroMovement
    {
        private class Position
        {
            public readonly int X;
            public readonly int Y;

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public void Move(Hero hero, Map map, Directions direction)
        {
            var finalPosition = GetFinalPosition(hero, direction);
            map.RemoveHero(hero.PositionX, hero.PositionY);
            map.AddHero(finalPosition.X, finalPosition.Y, hero);
            hero.SetPosition(finalPosition.X, finalPosition.Y);
        }

        private Position GetFinalPosition(Hero hero, Directions direction)
        {
            var incrementX = 0;
            var incrementY = 0;
            switch (direction)
            {
                case Directions.Right:
                    incrementX = 1;
                    break;
                case Directions.Left:
                    incrementX = -1;
                    break;
                case Directions.Up:
                    incrementY = 1;
                    break;
                case Directions.Down:
                    incrementY = -1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return new Position(hero.PositionX + incrementX, hero.PositionY + incrementY);
        }
    }
}
