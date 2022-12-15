using Subsets.Message2.Runtime;
using UnityEditor;
using UnityEngine;

namespace Subsets.Message2.Editor
{
    [CustomEditor(typeof(StringEvent), editorForChildClasses: true)]
    public class StringEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            StringEvent e = target as StringEvent;
            if (GUILayout.Button("Raise"))
            {
                e.Raise(e.Variable);
            }
        }
    }
}