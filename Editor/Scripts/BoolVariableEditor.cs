using UnityEditor;
using UnityEngine;
using Subsets.Message2.Runtime;

namespace Subsets.Message2.Editor
{
    [CustomEditor(typeof(BoolVariable), editorForChildClasses: true)]
    public class BoolVariableEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            if (GUILayout.Button("Raise Change Event"))
            {
                BoolVariable e = target as BoolVariable;
                if (e)
                {
                    e.Value = e.Value;
                }
            }
        }
    }
}