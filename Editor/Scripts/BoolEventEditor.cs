using Subsets.Message2.Runtime;
using UnityEditor;
using UnityEngine;

namespace Subsets.Message2.Editor
{
    [CustomEditor(typeof(BoolEvent), editorForChildClasses: true)]
    public class BoolEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            BoolEvent e = target as BoolEvent;
            if (GUILayout.Button("Raise"))
            {
                e.Raise(e.Variable);
            }
        }
    }
}