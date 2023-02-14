using UnityEditor;
using UnityEngine;
using Subsets.Dda;

namespace Subsets.Dda.Editor
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