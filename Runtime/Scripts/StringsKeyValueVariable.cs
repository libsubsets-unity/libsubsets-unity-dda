using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Dda
{
    [Serializable]
    public class StringsKeyValue<T>
    {
        public string Key;
        public T Value;
    }
    
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/StringsKeyValueVariable")]
    public class StringsKeyValueVariable : BaseVariable<List<StringsKeyValue<StringsVariable>>>
    {
        protected override List<StringsKeyValue<StringsVariable>> DuplicateValue(List<StringsKeyValue<StringsVariable>> value)
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
                variable.Value.name = String.Format("dynamic_value:{0}:{1}", name, id);
                Value.Add(variable);
            }
            return variable.Value;
        }

    }
}