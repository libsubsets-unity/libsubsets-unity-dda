using System.Collections.Generic;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        
        [System.NonSerialized] 
        public float Value;
        [SerializeField]
        public float InitValue;

        public void LoadInitValue()
        {
            Debug.Log("GameTestVariable::LoadInitValue");
            Value = InitValue;
        }
                
        public void OnBeforeSerialize()
        {
        }
                
        public void OnAfterDeserialize()
        {
            Debug.Log("GameTestVariable::OnAfterDeserialize");
            this.LoadInitValue();
        }
    }
}