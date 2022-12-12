using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
{
    public class IntegerVariableTrigger : MonoBehaviour
    {
        public IntegerVariable Variable;
        public ResponseConditionOperator ConditionOperator;
       
        public List<IntegerCondition> Conditions;
        public UnityEvent<IntegerVariable> Listeners;
        public void Awake()
        {
            Variable.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
            {
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (IntegerCondition condition in Conditions)
                {
                    if (condition.Compare == IntegerCompare.Equal)
                    {
                        result.Add(Variable.Value == condition.Value);
                    }
                    else if (condition.Compare == IntegerCompare.IsNot)
                    {
                        result.Add(Variable.Value != condition.Value);
                    }
                    else if (condition.Compare == IntegerCompare.Updated)
                    {
                       result.Add(true); 
                    }
                }

                if (result.CheckConditionOperator(ConditionOperator))
                {
                    Listeners?.Invoke(Variable);
                }
            };
        }
    }
}