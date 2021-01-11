using Battle.UseCases;

namespace Battle
{
    public interface IHeroMovement
    {
        HeroMovementOutputData Move(Directions direction);
    }
}
