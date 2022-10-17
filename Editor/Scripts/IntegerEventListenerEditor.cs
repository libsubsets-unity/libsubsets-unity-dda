using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Subsets.Message2.Runtime;

namespace Subsets.Message2.Editor
{
    [CustomEditor(typeof(IntegerEventListener))]
    public class IntegerEventListenerEditor : UnityEditor.Editor
    {
        private SerializedProperty eventProperty;
        private SerializedProperty conditionsProperty;
        private SerializedProperty responseProperty;
        
        public void OnEnable()
        {
            eventProperty = serializedObject.FindProperty("Event");
            conditionsProperty = serializedObject.FindProperty("Conditions");
            responseProperty = serializedObject.FindProperty("Response");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            IntegerEventListener e = target as IntegerEventListener;

            EditorGUILayout.PropertyField(eventProperty, new GUIContent("Event") );

            EditorGUILayout.PropertyField(conditionsProperty, new GUIContent("Conditions") );
            if (conditionsProperty.arraySize > 1)
            {
                e.ConditionOperator = (ResponseConditionOperator)EditorGUILayout.EnumPopup("Condition Operator", e.ConditionOperator);
            }
            EditorGUILayout.PropertyField(responseProperty, new GUIContent("Response") );

            serializedObject.ApplyModifiedProperties();
        }
    }
}