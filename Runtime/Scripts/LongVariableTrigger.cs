using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    public class LongVariableTrigger : MonoBehaviour
    {
        public LongVariable Variable;
        public ResponseConditionOperator ConditionOperator;
       
        public List<LongCondition> Conditions;
        public UnityEvent<LongVariable> Listeners;
        public void Awake()
        {
            Variable.PropertyChanged += OnExecute;
        }

        private void Destroy()
        {
            Variable.PropertyChanged -= OnExecute;
        }
        
        private void OnExecute(object sender, PropertyChangedEventArgs args)
        {
            ConditionCompareResult result = new ConditionCompareResult();
            foreach (LongCondition condition in Conditions)
            {
                if (condition.Compare == LongCompare.Equal)
                {
                    result.Add(Variable.Value == condition.Value);
                }
                else if (condition.Compare == LongCompare.IsNot)
                {
                    result.Add(Variable.Value != condition.Value);
                }
                else if (condition.Compare == LongCompare.Updated)
                {
                    result.Add(true);
                }
            }

            if (result.CheckConditionOperator(ConditionOperator))
            {
                Listeners?.Invoke(Variable);
            }
        }
    }
}