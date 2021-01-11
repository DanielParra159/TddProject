using UnityEngine;

namespace Battle.InterfaceAdapters
{
    public interface IMovementMotor
    {
        void UpdatePosition(Vector3 finalPosition);
    }
}
