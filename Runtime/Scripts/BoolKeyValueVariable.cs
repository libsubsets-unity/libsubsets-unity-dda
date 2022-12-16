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
    
    [CreateAssetMenu(menuName = "Message2/Variable/BoolKeyValue")]
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
        
        public BoolVariable Find(string id)
        {
            BoolKeyValue<BoolVariable> variable = Value.Find(value => value.Key.Equals(id));
            if (variable == null)
            {
                variable = new BoolKeyValue<BoolVariable>();
                variable.Key = id;
                variable.Value = ScriptableObject.CreateInstance<BoolVariable>();
                Value.Add(variable);
            }
            return variable.Value;
        }
    }
}