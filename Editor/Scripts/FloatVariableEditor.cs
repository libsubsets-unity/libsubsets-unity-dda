using UnityEditor;
using UnityEngine;
using Subsets.Dda;

namespace Subsets.Dda.Editor
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