using UnityEditor;
using UnityEngine;
using Subsets.Message2.Runtime;

namespace Subsets.Message2.Editor
{
    [CustomEditor(typeof(FloatVariable), editorForChildClasses: true)]
    public class VariableEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            if (GUILayout.Button("Raise Change Event"))
            {
                FloatVariable e = target as FloatVariable;
                if (e)
                {
                    e.Value = e.Value;
                }
            }
        }
    }
}