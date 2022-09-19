using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class StringsVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<string> Values;

        public void OnEnable()
        {
        }

        public void OnValidate()
        {
        }
    }
}
