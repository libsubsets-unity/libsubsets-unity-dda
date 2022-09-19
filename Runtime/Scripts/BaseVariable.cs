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
                    Debug.Log("BaseVariable::Reset: Init");
                    variable.Init();
                }    
            }
            
        }

        protected BaseVariable()
        {
            Debug.Log("BaseVariable::BaseVariable");
        }

        protected abstract void Init();
        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            Debug.Log("BaseVariable::OnAfterDeserialize");
            if (!Application.isEditor)
            {
                Debug.Log("BaseVariable::OnAfterDeserialize: Init");
                Init();
            }
        }
    }
}