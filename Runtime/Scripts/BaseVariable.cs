using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlayGem.JawRed.Core.Variables
{
    public abstract class BaseVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Reset()
        {
            Debug.Log("BaseVariable::Reset");
            if (Application.isEditor)
            {
                BaseVariable[] variables = Resources.FindObjectsOfTypeAll<BaseVariable>();
                foreach (BaseVariable variable in variables)
                {
                    Debug.Log("BaseVariable::Reset: Init. name is " + variable.name);
                    variable.Init();
                }    
            }
            
        }

        protected abstract void Init();
        public void OnBeforeSerialize()
        {
            Debug.Log("BaseVariable::OnBeforeDeserialize");
        }
        
        private void OnEnable()
        {
            Debug.Log("BaseVariable::OnEnable: name is " + name);
        }

        public void OnAfterDeserialize()
        {
            Debug.Log("BaseVariable::OnAfterDeserialize:" );
            if (!Application.isEditor)
            {
                Debug.Log("BaseVariable::OnAfterDeserialize: Init");
                Init();
            }
        }
    }
}