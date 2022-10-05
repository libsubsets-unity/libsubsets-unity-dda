using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;

namespace Subsets.Message2
{
    public static class RuntimeInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Reset()
        {
            Debug.Log("RuntimeEventInitializer reset");
                
            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
                IRuntimeInitialize initialize = asset as IRuntimeInitialize;
                initialize?.Reset();
            }
        }
    }
}