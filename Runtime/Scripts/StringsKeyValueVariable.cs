using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [Serializable]
    public class StringsKeyValue<T>
    {
        public string Key;
        public T Value;
    }
    
    [CreateAssetMenu(menuName = "Message2/Variable/StringsKeyValue")]
    public class StringsKeyValueVariable : BaseVariable<List<StringsKeyValue<StringsVariable>>>
    {
        protected override List<StringsKeyValue<StringsVariable>> Clone(List<StringsKeyValue<StringsVariable>> value)
        {
            if (null == value)
            {
                return new List<StringsKeyValue<StringsVariable>>();
            }
            return value.ToList();
        }

        public StringsVariable Find(string id)
        {
            StringsKeyValue<StringsVariable> variable = Value.Find(value => value.Key.Equals(id));
            if (variable == null)
            {
                variable = new StringsKeyValue<StringsVariable>();
                variable.Key = id;
                variable.Value = ScriptableObject.CreateInstance<StringsVariable>();
                Value.Add(variable);
            }
            return variable.Value;
        }

    }
}