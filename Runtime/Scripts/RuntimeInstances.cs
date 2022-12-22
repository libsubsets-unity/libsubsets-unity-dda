using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    public static class RuntimeInstances
    {
        private static HashSet<IRuntimeInitialize> instances = new HashSet<IRuntimeInitialize>();

        public static void Register(IRuntimeInitialize instance)
        {
            instances.Add(instance);
            Debug.Log("RuntimeInstances::Registered:: count: "+ instances.Count);
        }

        public static void Unregister(IRuntimeInitialize instance)
        {
            instances.Remove(instance);
            Debug.Log("RuntimeInstances::Unregistered:: count: "+ instances.Count);
        }

        public static HashSet<IRuntimeInitialize> GetInstances()
        {
            return instances;
        }
    }
}