namespace LibSubsets.SoA
{
    public interface IRuntimeInitialize
    {
        void RuntimeInitialize();
        void RaiseRuntimeInitializeEvent();
        void RuntimeFinalize();
    }
}