using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Dda
{
    public class RuntimeInitializerStateTrigger : MonoBehaviour
    {
        public UnityEvent<RuntimeInitializerState> Listeners;
        public List<RuntimeInitializerState> TriggerStates;
        
        public void Awake()
        {
            RuntimeInitializerSettings.StateChanged.AddListener(OnStateChanged);
        }

        public void OnDestroy()
        {
            RuntimeInitializerSettings.StateChanged.RemoveListener(OnStateChanged);
        }

        void OnStateChanged(RuntimeInitializerState state)
        {
            Debug.Log("RuntimeInitializerStateTrigger::OnStateChanged: state: " + state);
            foreach (RuntimeInitializerState trigger in TriggerStates)
            {
                if (trigger == state)
                {
                    Listeners?.Invoke(state);
                    break;
                }    
            }
        }
    }
}