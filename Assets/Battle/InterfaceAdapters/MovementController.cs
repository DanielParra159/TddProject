using Battle.SharedTypes;
using Battle.UseCases;
using UnityEngine;

namespace Battle.InterfaceAdapters
{
    public class MovementController
    {
        private readonly IMovementMotor _movementMotor;
        private readonly IHeroMovement _heroMovement;

        public MovementController(IMovementMotor movementMotor,
                                  IHeroMovement heroMovement)
        {
            _movementMotor = movementMotor;
            _heroMovement = heroMovement;
        }

        public void Move(float horizontal, float vertical)
        {
            if (Mathf.Approximately(horizontal , 0) 
             && Mathf.Approximately(vertical , 0))
            {
                return;
            }
            
            var direction = GetDirection(horizontal, vertical);

            var outputData = _heroMovement.Move(direction);
            _movementMotor.UpdatePosition(new Vector3(outputData.PositionX, outputData.PositionY, 0.0f));
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
