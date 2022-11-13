using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    public enum FloatCompare
    {
        Equal,
        IsNot
    }
    
    [Serializable]
    public class FloatCondition
    {
        public FloatCompare Compare;
        public int Value;
    }
    
    public class FloatEventListener : BaseEventListener<float>
    {
        public ResponseConditionOperator ConditionOperator;
        public float CompareEpsilon = 0.01f;
        public List<FloatCondition> Conditions;
        protected  override bool CheckCompareCondition()
        {
            FloatEvent e = Event as FloatEvent;
            if (e)
            {
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (FloatCondition condition in Conditions)
                {
                    if (condition.Compare == FloatCompare.Equal)
                    {
                        result.Add(IsEqual(e.Variable, condition.Value));
                    }
                    else if (condition.Compare == FloatCompare.IsNot)
                    {
                        result.Add(!IsEqual(e.Variable, condition.Value));
                    }
                }
                return result.CheckConditionOperator(ConditionOperator);
            }
            throw new Exception("Event type is wrong:" + Event.ToString());
        }

        private bool IsEqual(float a, float b)
        {
            return Math.Abs(a - b) < CompareEpsilon;
        }
    }
}