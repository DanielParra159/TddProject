using UnityEngine;

namespace Battle
{
    public class HeroView : MonoBehaviour, IMovementMotor
    {
        private MovementController movementController;

        private void Awake()
        {
            movementController =
                new MovementController(null,
                                       null,
                                       null);
        }

        private void FixedUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            movementController.Move(horizontal, vertical);
        }

        public void UpdatePosition(Vector3 finalPosition)
        {
            //transform.position = finalPosition;
        }
    }
}
