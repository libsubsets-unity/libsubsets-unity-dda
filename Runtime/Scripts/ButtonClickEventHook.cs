using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Subsets.Message2.Runtime
{
    public class ButtonClickEventHook : MonoBehaviour
    {
        public UnityEvent Event;
        
        public void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClickEvent);
        }

        public void Raise()
        {
            var button = GetComponent<Button>();
            button.onClick.RemoveListener(OnClickEvent);
        }

        private void OnClickEvent()
        {
            Event?.Invoke();
        }
    }
}