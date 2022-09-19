using System.Collections.Generic;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class BoolVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public bool Value;

        public void OnEnable()
        {
        }

        public void OnValidate()
        {
        }
    }
}
