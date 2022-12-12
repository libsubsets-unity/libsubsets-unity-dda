using System;
using System.Collections.Generic;

namespace Subsets.Message2.Runtime
{
    public enum ResponseConditionOperator
    {
        Or,
        And
    }
    public class ConditionCompareResult
    {
        private List<bool> compareResults = new List<bool>();

        public void Add(bool compare)
        {
            compareResults.Add(compare);
        }

        public bool CheckConditionOperator(ResponseConditionOperator conditionOperator)
        {
            int matchCount = 0;
            foreach (bool isMatch in compareResults)
            {
                if (isMatch)
                    matchCount++;
            }
            if (conditionOperator == ResponseConditionOperator.And)
            {
                return matchCount == compareResults.Count || compareResults.Count == 0;
            }
            else if (conditionOperator == ResponseConditionOperator.Or)
            {
                return matchCount > 0 || compareResults.Count == 0;
            }
            throw new Exception("ResponseConditionOperator is wrong: " + conditionOperator.ToString());
        }
    }
}