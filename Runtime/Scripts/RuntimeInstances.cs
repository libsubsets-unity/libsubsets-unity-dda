using System.Collections.Generic;

namespace Subsets.Message2.Runtime
{
    public static class RuntimeInstances
    {
        private static HashSet<IRuntimeInitialize> instances = new HashSet<IRuntimeInitialize>();
        
        public static void Register(IRuntimeInitialize instance)
        {
            instances.Add(instance);
        }

        public static void Unregister(IRuntimeInitialize instance)
        {
            instances.Remove(instance);
        }

        public static HashSet<IRuntimeInitialize> GetInstances()
        {
            return instances;
        }
    }
}