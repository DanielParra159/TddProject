using Battle.InterfaceAdapters;
using UnityEngine;
using Input = Battle.Utilities.Input;

namespace Battle.Views
{
    public class HeroView : MonoBehaviour, IMovementMotor
    {
        private MovementController movementController;
        private Input input;

        public void Configure(Input input, MovementController movementController)
        {
            this.input = input;
            this.movementController = movementController;
        }

        private void FixedUpdate()
        {
            var horizontal = input.GetAxis("Horizontal");
            var vertical = input.GetAxis("Vertical");

            movementController.Move(horizontal, vertical);
        }

        public void UpdatePosition(Vector3 finalPosition)
        {
            transform.position = finalPosition;
        }
    }
}
