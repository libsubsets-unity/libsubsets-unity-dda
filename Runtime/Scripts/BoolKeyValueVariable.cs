using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [Serializable]
    public class BoolKeyValue<T>
    {
        public string Key;
        public T Value;
    }
    
    [CreateAssetMenu]
    public class BoolKeyValueVariable : BaseVariable<List<BoolKeyValue<BoolVariable>>>
    {
        protected override List<BoolKeyValue<BoolVariable>> Clone(List<BoolKeyValue<BoolVariable>> value)
        {
            if (null == value)
            {
                return new List<BoolKeyValue<BoolVariable>>();
            }
            return value.ToList();
        }
    }
}