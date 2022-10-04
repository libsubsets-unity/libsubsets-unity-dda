using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using PlayGem.JawRed.Core.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public class BoolVariableTrigger : MonoBehaviour
    {
        public BoolVariable Variable;
        public BoolCondition Condition;
        public UnityEvent<BoolVariable> Listeners;
        
        public void Awake()
        {
            Variable.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
            {
                Debug.Log("State Changed:" + Variable.Value);
                if (Condition.Compare == BoolCompare.IsTrue)
                {
                    if (Variable.Value == true)
                    {
                        Listeners.Invoke(Variable);
                    }
                }
                else if (Condition.Compare == BoolCompare.IsFalse)
                {
                    if (Variable.Value == false)
                    {
                        Listeners.Invoke(Variable);
                    }
                }
            };
        }
    }
}