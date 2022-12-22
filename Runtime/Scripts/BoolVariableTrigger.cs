using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    public class BoolVariableTrigger : MonoBehaviour
    {
        public BoolVariable Variable;
        public BoolCondition Condition;
        public bool StopWhenConditionMatched;
        public UnityEvent<BoolVariable> Listeners;
       
        private void OnEnable()
        {
        }
        public void Awake()
        {
            Variable.PropertyChanged += OnExecute;
        }

        private void OnDestroy()
        {
            Variable.PropertyChanged -= OnExecute;
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
                    if (Variable.Value == true)
                    {
                        Listeners.Invoke(Variable);
                        if (StopWhenConditionMatched)
                        {
                            enabled = false;
                        }
                    }
                }
                else if (Condition.Compare == BoolCompare.IsFalse)
                {
                    if (Variable.Value == false)
                    {
                        Listeners.Invoke(Variable);
                        if (StopWhenConditionMatched)
                        {
                            enabled = false;
                        }
                    }
                }
                else if(Condition.Compare == BoolCompare.Updated)
                {
                    Listeners.Invoke(Variable);
                    if (StopWhenConditionMatched)
                    {
                        enabled = false;
                    }
                }
            }           
        }
    }
}