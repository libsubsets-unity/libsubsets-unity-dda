using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Subsets.Message2.Editor
{
    [CustomEditor(typeof(BoolEventListener))]
    public class BoolEventListenerEditor : UnityEditor.Editor
    {
        private SerializedProperty eventProperty;
        private SerializedProperty conditionProperty;
        private SerializedProperty responseProperty;
        
        public void OnEnable()
        {
            eventProperty = serializedObject.FindProperty("Event");
            conditionProperty = serializedObject.FindProperty("Condition");
            responseProperty = serializedObject.FindProperty("Response");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            BoolEventListener e = target as BoolEventListener;

            EditorGUILayout.PropertyField(eventProperty, new GUIContent("Event") );
            EditorGUILayout.PropertyField(conditionProperty, new GUIContent("Condition") );
            EditorGUILayout.PropertyField(responseProperty, new GUIContent("Response") );

            serializedObject.ApplyModifiedProperties();
        }
    }
}