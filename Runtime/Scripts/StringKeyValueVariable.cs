using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [Serializable]
    public class StringKeyValue<T>
    {
        public string Key;
        public T Value;
    }
    
    [CreateAssetMenu]
    public class StringKeyValueVariable : BaseVariable<List<StringKeyValue<StringVariable>>>
    {
        protected override List<StringKeyValue<StringVariable>> Clone(List<StringKeyValue<StringVariable>> value)
        {
            if (null == value)
            {
                return new List<StringKeyValue<StringVariable>>();
            }
            return value.ToList();
        }
    }
}