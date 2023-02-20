using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Dda
{
    public abstract class BaseVariable<T> : ScriptableObject, INotifyPropertyChanged, IRuntimeInitialize, ISerializationCallbackReceiver
    {
        
        [Multiline]
        public string DeveloperDescription = "";
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.OldValue = this.value;
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public T InitialValue
        {
            get
            {
               return this.initialValue;
            }
            set
            {
                this.initialValue = value;
                OnPropertyChanged("InitialValue");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [SerializeField] private T initialValue;
        [SerializeField] private T value;
        [NonSerialized]
        public T OldValue;

        private string valueName;

        public void Awake()
        {
        }
        
        public void OnDestroy()
        {
        }

        private void OnEnable()
        {
            this.valueName = name;
            Debug.Log("BaseVariable::OnEnable: name is " + ( valueName.Length == 0 ? "none": valueName));
            
            RuntimeInstances.Register(this);
            RuntimeInitialize();
            RaiseRuntimeInitializeEvent();
        }
        
        private void OnDisable()
        {
            Debug.Log("BaseVariable::OnDisable: name is " + ( valueName.Length == 0 ? "none": valueName));
            
            RuntimeFinalize();
            RuntimeInstances.Unregister(this);
        }


        private void Reset()
        {
        }

        public virtual void RuntimeInitialize()
        {
            Debug.Log("BaseVariable::RuntimeInitialize: name is " + ( valueName.Length == 0 ? "none" : valueName));
            if (initialValue != null)
            {
                this.value = DuplicateValue(initialValue);
            }
        }

        public virtual void RaiseRuntimeInitializeEvent()
        {
            Debug.Log("BaseVariable::RaiseRuntimeInitializeEvent: name is " +
                      (valueName.Length == 0 ? "none" : valueName));
            OnPropertyChanged("Value");
        }

        public virtual void RuntimeFinalize()
        {
            Debug.Log("BaseVariable::RuntimeFinalize: name is " + (valueName.Length == 0 ? "none" : valueName));
            PropertyChanged = null;
        }

        protected abstract T DuplicateValue(T value);

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public virtual void OnBeforeSerialize()
        {
        }
        
        public virtual void OnAfterDeserialize()
        {
        }
    }
}