using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    public enum StringCompare
    {
        Equal,
        Contains,
        IsNot
    }
    
    public class StringCondition
    {
        public StringCompare Compare;
        public string Value;
    }
    public class StringEventListener : GameEventListener
    {
        public ResponseConditionOperator ConditionOperator;
        [NonReorderable]
        public List<StringCondition> Conditions;
        
        protected  override bool CheckCompareCondition()
        {
            StringEvent e = Event as StringEvent;
            if (e)
            {
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (StringCondition condition in Conditions)
                {
                    if (condition.Compare == StringCompare.Equal)
                    {
                        result.Add(e.Variable == condition.Value);
                    }
                    else if (condition.Compare == StringCompare.Contains)
                    {
                        result.Add(e.Variable.Contains(condition.Value));
                    }
                    else if (condition.Compare == StringCompare.IsNot)
                    {
                        result.Add(e.Variable != condition.Value);
                    }    
                }

                return result.CheckConditionOperator(ConditionOperator);
            }
            throw new Exception("Event type is wrong:" + Event.ToString());
        }
    }
}