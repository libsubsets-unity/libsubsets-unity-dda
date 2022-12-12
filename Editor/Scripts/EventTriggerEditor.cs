using Subsets.Message2.Runtime;
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.Events;

namespace Subsets.Message2.Editor
{
    public class BindableEvent
    {
        public UnityEventBase UnityEvent { get; set; }
    
        public string Name { get; set; }
    
        public Type DeclaringType { get; set; }
    
        public Type ComponentType { get; set; }
    }

    [CustomEditor(typeof(EventTrigger))]
    public class EventTriggerEditor : UnityEditor.Editor
    {
        private EventTrigger trigger;
        
        private void OnEnable()
        {
            trigger = (EventTrigger)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            BindableEvent[] events = GetBindableEvents(trigger.gameObject);
            var eventNames = events.Select(BindableEventToString).ToArray();
            var selectedIndex = Array.IndexOf(eventNames, trigger.ViewEventName);
            var content = events.Select(evt => new GUIContent(evt.ComponentType.Name + "." + evt.Name)).ToArray();
            var newSelectedIndex = EditorGUILayout.Popup(
                new GUIContent("View event", "Event on the view to bind to."),
                selectedIndex,
                content);
            trigger.ViewEventName = eventNames[newSelectedIndex];

            serializedObject.ApplyModifiedProperties();
        }
        
        public static BindableEvent[] GetBindableEvents(
            GameObject gameObject) 
        {
            return gameObject.GetComponents(typeof(Component))
                .Where(component => component != null)
                .SelectMany(GetBindableEvents)
                .ToArray();
        }
        
        private static string BindableEventToString(BindableEvent evt)
        {
            return string.Concat(evt.ComponentType.ToString(), ".", evt.Name);
        }
        
        
        private static IEnumerable<BindableEvent> GetBindableEvents(Component component)
        {
            var type = component.GetType();
    
            var bindableEventsFromProperties = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(propertyInfo => propertyInfo.PropertyType.IsSubclassOf(typeof(UnityEventBase)))
                .Where(propertyInfo => !propertyInfo.GetCustomAttributes(typeof(ObsoleteAttribute), true).Any())
                .Select(propertyInfo => new BindableEvent()
                {
                    UnityEvent = (UnityEventBase)propertyInfo.GetValue(component, null),
                    Name = propertyInfo.Name,
                    DeclaringType = propertyInfo.DeclaringType,
                    ComponentType = component.GetType()
                });
    
            var bindableEventsFromFields = type
                .GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(fieldInfo => fieldInfo.FieldType.IsSubclassOf(typeof(UnityEventBase)))
                .Where(fieldInfo => !fieldInfo.GetCustomAttributes(typeof(ObsoleteAttribute), true).Any())
                .Select(fieldInfo => new BindableEvent
                {
                    UnityEvent = (UnityEventBase)fieldInfo.GetValue(component),
                    Name = fieldInfo.Name,
                    DeclaringType = fieldInfo.DeclaringType,
                    ComponentType = type
                });
    
            return bindableEventsFromFields.Concat(bindableEventsFromProperties);
        }
    }
}