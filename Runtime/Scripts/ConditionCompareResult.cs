using System;
using System.Collections.Generic;

namespace Subsets.Message2
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
                if (matchCount == compareResults.Count || compareResults.Count == 0)
                {
                    return true;
                }    
            }
            else if (conditionOperator == ResponseConditionOperator.Or)
            {
                if (matchCount > 0 || compareResults.Count == 0)
                {
                    return true;
                }
            }
            throw new Exception("ResponseConditionOperator is wrong: " + conditionOperator.ToString());
        }
    }
}