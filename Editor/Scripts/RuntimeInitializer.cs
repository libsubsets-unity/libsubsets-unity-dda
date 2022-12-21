using System;
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
            EditorApplication.playModeStateChanged -= OnStateChanged; 
            EditorApplication.playModeStateChanged += OnStateChanged; 
        }
        
        static void OnStateChanged(PlayModeStateChange change)
        {
            Debug.Log(String.Format("RuntimeInitializer::OnStateChanged: EnterPlayMode : {0}, Options:{1}, StateChanged: {2}",
                EditorSettings.enterPlayModeOptionsEnabled, EditorSettings.enterPlayModeOptions.ToString(), change));
            if (EditorSettings.enterPlayModeOptionsEnabled &&
                EditorSettings.enterPlayModeOptions.HasFlag(EnterPlayModeOptions.DisableDomainReload))
            {
                if (change == PlayModeStateChange.ExitingEditMode)
                {
                    Initialize(); 
                }

                else if (change == PlayModeStateChange.EnteredPlayMode)
                {
                    //This event is synchronized with the editor application's update loop,
                    //it may occur after the game's update loop has already executed one or more times
                    RaiseRuntimeInitialize(); 
                }
            }
        }

        public static void Initialize()
        {
            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                ScriptableObject asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
                IRuntimeFinalization finalize = asset as IRuntimeFinalization;
                finalize?.RuntimeFinalize();
                IRuntimeInitialize initialize = asset as IRuntimeInitialize;
                initialize?.RuntimeInitialize();
            }
        }

        public static void RaiseRuntimeInitialize()
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