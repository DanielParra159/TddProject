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

        private readonly Hero _hero;
        private readonly Map _map;

        public HeroMovement(Hero hero, Map map)
        {
            _hero = hero;
            _map = map;
        }
        
        public void Move(Directions direction)
        {
            var finalPosition = GetFinalPosition(_hero, direction);
            _map.RemoveHero(_hero.PositionX, _hero.PositionY);
            _map.AddHero(finalPosition.X, finalPosition.Y, _hero);
            _hero.SetPosition(finalPosition.X, finalPosition.Y);
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
