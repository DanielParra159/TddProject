namespace Battle
{
    public interface IHeroMovement
    {
        void Move(Hero hero, Map map, Directions direction);
    }
}