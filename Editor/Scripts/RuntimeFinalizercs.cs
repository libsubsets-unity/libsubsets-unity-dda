using Subsets.Message2.Runtime;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;

namespace Subsets.Message2.Editor
{
    public static class RuntimeFinalizer
    {
        [InitializeOnLoadMethod]
        static void Register()
        {
            EditorApplication.playModeStateChanged += UpdateFinalize; 
        }

        static void UpdateFinalize(PlayModeStateChange change)
        {
            if (EditorSettings.enterPlayModeOptionsEnabled &&
                EditorSettings.enterPlayModeOptions.HasFlag(EnterPlayModeOptions.DisableDomainReload) &&
                change == PlayModeStateChange.ExitingPlayMode)
            {
               Finalize(); 
            }
        }

        public static void Finalize()
        {
            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                IRuntimeFinalization finalize =
                    AssetDatabase.LoadAssetAtPath<ScriptableObject>(path) as IRuntimeFinalization;
                finalize?.Finalize();
            }
        }
    }
}