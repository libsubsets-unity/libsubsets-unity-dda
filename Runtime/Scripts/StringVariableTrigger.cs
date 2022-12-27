using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    [Serializable]
    public class StringVariableCondition : BaseCondition<StringVariable, string>
    {
        public StringCompare Compare;
        public string Value;
    }
    public class StringVariableTrigger : BaseTrigger<StringVariableCondition, StringVariable, string>
    {
        

        public ResponseConditionOperator ConditionOperator;

        protected override bool MatchCondition()
        {
            if (enabled)
            {
                ConditionCompareResult result = new ConditionCompareResult();
                foreach (StringVariableCondition condition in Conditions)
                {
                    if (condition.Compare == StringCompare.Equal)
                    {
                        result.Add(condition.Target.Value.Equals(condition.Value));
                    }
                    else if (condition.Compare == StringCompare.Contains)
                    {
                        result.Add(condition.Target.Value.Contains(condition.Value));
                    }
                    else if (condition.Compare == StringCompare.IsNot)
                    {
                        result.Add(!condition.Target.Value.Equals(condition.Value));
                    }
                    else if (condition.Compare == StringCompare.Updated)
                    {
                        result.Add(true);
                    }
                }

                if (result.CheckConditionOperator(ConditionOperator))
                {
                    Listeners?.Invoke();
                }
            }

            return false;
        }
    }
}