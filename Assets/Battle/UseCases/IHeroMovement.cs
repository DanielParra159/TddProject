using Battle.SharedTypes;

namespace Battle.UseCases
{
    public interface IHeroMovement
    {
        HeroMovementOutputData Move(Directions direction);
    }
}
