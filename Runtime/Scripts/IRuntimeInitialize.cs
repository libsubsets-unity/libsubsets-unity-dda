namespace Subsets.Message2.Runtime
{
    public interface IRuntimeInitialize
    {
        void RuntimeInitialize();
        void RaiseRuntimeInitializeEvent();
    }
}