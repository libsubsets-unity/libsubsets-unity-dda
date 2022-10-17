using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Subsets.Message2.Runtime
{
    public class TestGameEventListener : MonoBehaviour
    {
        public string ViewEventName;
        
        public UnityEvent Listeners;
        public UnityEvent<int> Listeners2;

        public void Awake()
        {
            UnityEngine.EventSystems.EventTrigger trigger = GetComponent<UnityEngine.EventSystems.EventTrigger>();
        }

        public void Raise()
        {
            /*
            if (Listeners != null)
            {
                Listeners.Invoke();
            }
            */
        }

        public void TestMethod(int param)
        {
            Debug.Log(param);
        }
    }
}