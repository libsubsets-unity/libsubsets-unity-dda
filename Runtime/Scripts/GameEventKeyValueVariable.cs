using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [Serializable]
    public class GameEventKeyValue<T>
    {
        public string Key;
        public T Value;
    }
    
    [CreateAssetMenu(menuName = "Message2/Variable/GameEventKeyValue")]
    public class GameEventKeyValueVariable : BaseVariable<List<GameEventKeyValue<GameEventVariable>>>
    {
        protected override List<GameEventKeyValue<GameEventVariable>> Clone(List<GameEventKeyValue<GameEventVariable>> value)
        {
            if (null == value)
            {
                return new List<GameEventKeyValue<GameEventVariable>>();
            }
            return value.ToList();
        }

        public GameEventVariable Find(string id)
        {
            GameEventKeyValue<GameEventVariable> variable = Value.Find(value => value.Key.Equals(id));
            if (variable == null)
            {
                variable = new GameEventKeyValue<GameEventVariable>();
                variable.Key = id;
                variable.Value = ScriptableObject.CreateInstance<GameEventVariable>();
                variable.Value.name = String.Format("dynamic_value:{0}:{1}", name, id);
                Value.Add(variable);
            }
            return variable.Value;
        }

    }
}