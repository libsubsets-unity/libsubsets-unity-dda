using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
{
    public class BoolKeyValueVariableTrigger : MonoBehaviour
    {
        public string Id;
        public BoolKeyValueVariable Variable;
        public BoolCondition Condition;
        public bool StopWhenConditionMatched;
        public UnityEvent<BoolVariable> Listeners;
       
        private void OnEnable()
        {
        }
        public void Awake()
        {
            Variable.Find(Id).PropertyChanged += OnExecute;
        }

        public void OnDestroy()
        {
            Variable.Find(Id).PropertyChanged -= OnExecute;
        }

        private void OnExecute(object sender, PropertyChangedEventArgs args)
        {
            Execute();
        }

        private void Execute()
        {
            if (enabled)
            {
                if (Condition.Compare == BoolCompare.IsTrue)
                {
                    if (Variable.Find(Id).Value == true)
                    {
                        Listeners.Invoke(Variable.Find(Id));
                        if (StopWhenConditionMatched)
                        {
                            enabled = false;
                        }
                    }
                }
                else if (Condition.Compare == BoolCompare.IsFalse)
                {
                    if (Variable.Find(Id).Value == false)
                    {
                        Listeners.Invoke(Variable.Find(Id));
                        if (StopWhenConditionMatched)
                        {
                            enabled = false;
                        }
                    }
                }
                else if (Condition.Compare == BoolCompare.Updated)
                {
                    Listeners.Invoke(Variable.Find(Id));
                    if (StopWhenConditionMatched)
                    {
                        enabled = false;
                    }
                }
            }           
        }
    }
}