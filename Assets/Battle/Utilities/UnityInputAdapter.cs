namespace Battle.Utilities
{
    public class UnityInputAdapter : Input
    {
        public float GetAxis(string axis)
        {
            return UnityEngine.Input.GetAxis(axis);
        }
    }
}
