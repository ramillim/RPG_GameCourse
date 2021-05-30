namespace UnityEngine.PostProcessing
{
    public sealed class IsMinAttribute : PropertyAttribute
    {
        public readonly float min;

        public IsMinAttribute(float min)
        {
            this.min = min;
        }
    }
}
