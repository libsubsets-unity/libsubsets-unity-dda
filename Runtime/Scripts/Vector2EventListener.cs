using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
{
    public enum Vector2Compare
    {
        Equal,
        BiggerThan,
        LittleThan,
    }
   
    [Serializable]
    public class Vector2Condition
    {
        public Vector2Compare Compare;
        public Vector2 Value;
    }
    public class Vector2EventListener : BaseEventListener<Vector2>
    {
        static public float CompareEpsilon = 0.01f;
    
        public ResponseConditionOperator ConditionOperator;
        [NonReorderable] 
        public List<Vector2Condition> Conditions = new List<Vector2Condition>();
        
        protected  override bool CheckCompareCondition()
        {
            Vector2Event e = Event as Vector2Event;
            if (e)
            {
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (Vector2Condition condition in Conditions)
                {
                    if (condition.Compare == Vector2Compare.Equal)
                    {
                        bool isEqual = Mathf.Abs(condition.Value.magnitude - e.Variable.magnitude) < CompareEpsilon;
                        result.Add(isEqual);
                    }
                    else if (condition.Compare == Vector2Compare.BiggerThan)
                    {
                        bool isBiggerThan = condition.Value.sqrMagnitude > e.Variable.sqrMagnitude;
                        result.Add(isBiggerThan);
                    }
                    else if (condition.Compare == Vector2Compare.LittleThan)
                    {
                        bool isLittleThan = condition.Value.sqrMagnitude < e.Variable.sqrMagnitude;
                        result.Add(isLittleThan);
                    }    
                }

                return result.CheckConditionOperator(ConditionOperator);
            }
            throw new Exception("Event type is wrong:" + Event.ToString());
        }
    }
}