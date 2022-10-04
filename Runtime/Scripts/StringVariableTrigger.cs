using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using PlayGem.JawRed.Core.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public class StringVariableTrigger : MonoBehaviour
    {
        public StringVariable Variable;
        public ResponseConditionOperator ConditionOperator;
        [NonReorderable] public List<StringCondition> Conditions = new List<StringCondition>();
        public UnityEvent<StringVariable> Listeners;
        
        public void Awake()
        {
            Variable.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
            {
                Debug.Log("State Changed:" + Variable.Value);
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (StringCondition condition in Conditions)
                {
                    if (condition.Compare == StringCompare.Equal)
                    {
                        result.Add(Variable.Value == condition.Value);
                    }
                    else if (condition.Compare == StringCompare.Contains)
                    {
                        result.Add(Variable.Value.Contains(condition.Value));
                    }
                    else if (condition.Compare == StringCompare.IsNot)
                    {
                        result.Add(Variable.Value != condition.Value);
                    }    
                }

                if (result.CheckConditionOperator(ConditionOperator))
                {
                    Listeners.Invoke(Variable);
                }
            };
        }
    }
}