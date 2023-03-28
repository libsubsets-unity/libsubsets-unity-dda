using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Dda
{
    public class StringVariableTrigger : BaseTrigger<StringVariableComparer, StringVariable>
    {
        public ResponseConditionOperator ConditionOperator;

        protected override bool MatchCondition()
        {
            if (enabled)
            {
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (StringVariableComparer condition in Conditions)
                {
                    result.Add(condition.Match());
                }

                if (result.CheckConditionOperator(ConditionOperator))
                {
                    return true;
                }
            }

            return false;
        }
    }
}