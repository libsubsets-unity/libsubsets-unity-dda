using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LibSubsets.SoA
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

        public T InitialValue;
        public T OldValue;
        public event PropertyChangedEventHandler PropertyChanged;

        [SerializeField] private T value;

        private string variableName;

        public void Awake()
        {
        }
        
        public void OnDestroy()
        {
        }

        private void OnEnable()
        {
            this.variableName = name;
            RuntimeInstances.Register(this);
            
            Debug.Log("BaseVariable::OnEnable: name is " + ( variableName.Length == 0 ? "dynamic_value:none": variableName));
            RuntimeInitialize();
            RaiseRuntimeInitializeEvent();
        }
        
        private void OnDisable()
        {
            RuntimeInstances.Unregister(this);
            
            Debug.Log("BaseVariable::OnDisable: name is " + ( variableName.Length == 0 ? "dynamic_value:none": variableName));
            RuntimeFinalize();
        }


        private void Reset()
        {
        }

        public virtual void RuntimeInitialize()
        {
            Debug.Log("BaseVariable::RuntimeInitialize: name is " + ( variableName.Length == 0 ? "dynamic_value:none" : variableName));
            this.value = Clone(InitialValue);
        }

        public virtual void RaiseRuntimeInitializeEvent()
        {
            Debug.Log("BaseVariable::RaiseRuntimeInitializeEvent: name is " +
                      (variableName.Length == 0 ? "dynamic_value:none" : variableName));
            OnPropertyChanged("Value");
        }

        public virtual void RuntimeFinalize()
        {
            Debug.Log("BaseVariable::RuntimeFinalize: name is " + (variableName.Length == 0 ? "dynamic_value:none" : variableName));
            PropertyChanged = null;
        }

        protected abstract T Clone(T value);

        private void OnPropertyChanged(string propertyName)
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