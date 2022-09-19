using System.Collections.Generic;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class StringVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public string Value;

        public void OnEnable()
        {
        }

        public void OnValidate()
        {
        }
    }
}
