using Subsets.Message2.Runtime;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;

namespace Subsets.Message2.Editor
{
    public static class RuntimeInitializer
    {
        [InitializeOnLoadMethod]
        public static void RegisterInitialize()
        {
            EditorApplication.playModeStateChanged += OnStateChanged; 
        }
        
        static void OnStateChanged(PlayModeStateChange change)
        {
            if (EditorSettings.enterPlayModeOptionsEnabled &&
                EditorSettings.enterPlayModeOptions.HasFlag(EnterPlayModeOptions.DisableDomainReload))
            {
                if (change == PlayModeStateChange.ExitingPlayMode)
                {
                    //Occurs when exiting play mode, before the Editor is in edit mode
                    Initialize(); 
                }

                else if (change == PlayModeStateChange.EnteredPlayMode)
                {
                    //This event is synchronized with the editor application's update loop,
                    //it may occur after the game's update loop has already executed one or more times
                    Finalize(); 
                }
            }
        }

        public static void Initialize()
        {
            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                IRuntimeFinalization finalizae = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path) as IRuntimeFinalization;
                finalizae?.RuntimeFinalize();
                IRuntimeInitialize initialize = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path) as IRuntimeInitialize;
                initialize?.RuntimeInitialize();
            }
        }

        public static void Finalize()
        {
            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                IRuntimeInitialize initialize = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path) as IRuntimeInitialize;
                initialize?.RaiseRuntimeInitializeEvent();
            }           
        }
    }
}