using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace PlayGem.JawRed.Core.Variables
{
    public  class BaseVariable<T> : ScriptableObject, ISerializationCallbackReceiver, INotifyPropertyChanged
    {
        /*
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
        */
        
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
                    
        }
                
        [SerializeField]
        private T value;
        
        public T InitValue;
                        
                
        protected virtual void Init()
        {
            Value = InitValue;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnBeforeSerialize()
        {
            Debug.Log("BaseVariable::OnBeforeDeserialize");
        }
        
        private void OnEnable()
        {
            Init();
            Debug.Log("BaseVariable::OnEnable: name is " + name);
        }

        public void OnAfterDeserialize()
        {
            Debug.Log("BaseVariable::OnAfterDeserialize:" );
        }
    }
}