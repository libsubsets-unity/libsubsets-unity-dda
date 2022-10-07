using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Subsets.Message2;
using UnityEngine;
using UnityEngine.Events;

namespace PlayGem.JawRed.Core.Variables
{
    public  class BaseVariable<T> : ScriptableObject, ISerializationCallbackReceiver, INotifyPropertyChanged, IRuntimeInitialize
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
                    
        }
        public T InitialValue;
        public event PropertyChangedEventHandler PropertyChanged;

        [SerializeField] private T value;

        public void Reset()
        {
            PropertyChanged = null;
            Initialize();
        }

        protected virtual void Initialize()
        {
            Value = InitialValue;
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnBeforeSerialize()
        {
        }
        
        private void OnEnable()
        {
            Debug.Log("BaseVariable::OnEnable: name is " + name);
            Initialize();
        }

        public void OnAfterDeserialize()
        {
        }
    }
}