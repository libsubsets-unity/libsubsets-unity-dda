using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace LibSubsets.SoA
{
    [Serializable]
    public class LongKeyValue<T>
    {
        public string Key;
        public T Value;
    }
    
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Variable/LongKeyValue")]
    public class LongKeyValueVariable : BaseVariable<List<LongKeyValue<LongVariable>>>
    {
        protected override List<LongKeyValue<LongVariable>> Clone(List<LongKeyValue<LongVariable>> value)
        {
            if (null == value)
            {
                return new List<LongKeyValue<LongVariable>>();
            }
            return value.ToList();
        }

        public LongVariable Find(string id)
        {
            LongKeyValue<LongVariable> variable = Value.Find(value => value.Key.Equals(id));
            if (variable == null)
            {
                variable = new LongKeyValue<LongVariable>();
                variable.Key = id;
                variable.Value = ScriptableObject.CreateInstance<LongVariable>();
                variable.Value.name = String.Format("dynamic_value:{0}:{1}", name, id);
                Value.Add(variable);
            }
            return variable.Value;
        }

    }
}