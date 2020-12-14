using UnityEngine;

namespace Battle
{
    public interface IMovementMotor
    {
        void UpdatePosition(Vector3 finalPosition);
    }
}