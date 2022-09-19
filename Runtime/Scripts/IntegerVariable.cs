using System.Collections.Generic;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class IntegerVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value;

        public void OnEnable()
        {
        }

        public void OnValidate()
        {
        }
    }
}
