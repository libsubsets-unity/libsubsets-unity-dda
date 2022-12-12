using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
{
    public enum IntegerCompare
    {
        Equal,
        IsNot,
        Updated
    }
    
    [Serializable]
    public class IntegerCondition
    {
        public IntegerCompare Compare;
        public int Value;
    }
    
    public class IntegerEventListener : BaseEventListener<int>
    {
        public ResponseConditionOperator ConditionOperator;
       
        public List<IntegerCondition> Conditions;
        protected  override bool CheckCompareCondition()
        {
            IntegerEvent e = Event as IntegerEvent;
            if (e)
            {
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (IntegerCondition condition in Conditions)
                {
                    if (condition.Compare == IntegerCompare.Equal)
                    {
                        result.Add(e.Variable == condition.Value);
                    }
                    else if (condition.Compare == IntegerCompare.IsNot)
                    {
                        result.Add(e.Variable != condition.Value);
                    }
                    else if (condition.Compare == IntegerCompare.Updated)
                    {
                        result.Add(true);
                    }
                }
                return result.CheckConditionOperator(ConditionOperator);
            }
            throw new Exception("Event type is wrong:" + Event.ToString());
        }
    }
}