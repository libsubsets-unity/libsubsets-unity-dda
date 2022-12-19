using Subsets.Message2.Runtime;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;

namespace Subsets.Message2.Editor
{
    public static class RuntimeInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Register()
        {
            if (EditorSettings.enterPlayModeOptionsEnabled &&
                EditorSettings.enterPlayModeOptions.HasFlag(EnterPlayModeOptions.DisableDomainReload))
            {
                Initialize();
            }
        }

        public static void Initialize()
        {
            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                IRuntimeInitialize initialize = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path) as IRuntimeInitialize;
                initialize?.Initialize();
            }
        }
    }
}