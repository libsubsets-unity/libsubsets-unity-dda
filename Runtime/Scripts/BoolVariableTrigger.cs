using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Dda
{
    [Serializable]
    public class BoolVariableComparer : BaseComparer<BoolVariable>
    {
        public BoolCompare Compare;
        public string Value;
    }
    public class BoolVariableTrigger : BaseTrigger<BoolVariableComparer, BoolVariable>
    {
        protected override bool MatchCondition()
        {
            if (enabled)
            {
                bool matched = false;
                foreach (BoolVariableComparer condition in Conditions)
                {
                    if (condition.Compare == BoolCompare.IsTrue)
                    {
                        matched = condition.Target == true;
                    }
                    else if (condition.Compare == BoolCompare.IsFalse)
                    {
                        matched = condition.Target == false;
                    }
                    else if(condition.Compare == BoolCompare.Updated)
                    {
                        matched = true;
                    }    
                }
                return matched;
            }
            return false;
        }
    }
}