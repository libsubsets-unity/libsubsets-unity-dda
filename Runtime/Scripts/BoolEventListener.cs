using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    public enum BoolCompare
    {
        IsTrue,
        IsFalse,
        Updated,
    }

    [Serializable]
    public class BoolCondition
    {
        public BoolCompare Compare;
    }
 
    public class BoolEventListener : BaseEventListener<bool>
    {
        public BoolCondition Condition;
        protected  override bool CheckCompareCondition()
        {
            BoolEvent e = Event as BoolEvent;
            if (e)
            {
                if (Condition.Compare == BoolCompare.IsTrue)
                {
                    return e.Variable == true;
                }
                else if (Condition.Compare == BoolCompare.IsFalse)
                {
                    return e.Variable == false;
                }
                else if (Condition.Compare == BoolCompare.Updated)
                {
                    return true;
                }

                return false;
            }
            throw new Exception("Event type is wrong:" + Event.ToString());
        }
    }
}