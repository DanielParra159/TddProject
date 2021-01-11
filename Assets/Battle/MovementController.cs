using UnityEngine;

namespace Battle
{
    public class MovementController
    {
        private readonly IMovementMotor _movementMotor;
        private readonly IHeroMovement _heroMovement;
        private readonly Hero _hero;
        private readonly Map _map;

        public MovementController(IMovementMotor movementMotor,
                                  IHeroMovement heroMovement,
                                  Hero hero, 
                                  Map map)
        {
            _movementMotor = movementMotor;
            _heroMovement = heroMovement;
            _hero = hero;
            _map = map;
        }

        public void Move(float horizontal, float vertical)
        {
            if (Mathf.Approximately(horizontal , 0) 
             && Mathf.Approximately(vertical , 0))
            {
                return;
            }
            
            var direction = GetDirection(horizontal, vertical);

            _heroMovement.Move(direction);
            _movementMotor.UpdatePosition(new Vector3(_hero.PositionX, _hero.PositionY, 0.0f));
        }

        private static Directions GetDirection(float horizontal, float vertical)
        {
            var direction = Directions.Down;

            if (horizontal < 0)
            {
                direction = Directions.Left;
            }
            else if (horizontal > 0)
            {
                direction = Directions.Right;
            }
            else if (vertical < 0)
            {
                direction = Directions.Down;
            }
            else if (vertical > 0)
            {
                direction = Directions.Up;
            }

            return direction;
        }
    }
}
