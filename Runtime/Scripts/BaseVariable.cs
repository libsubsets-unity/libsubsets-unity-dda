using System;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    public abstract class BaseVariable<T> : ScriptableObject, INotifyPropertyChanged, IRuntimeInitialize, IRuntimeFinalization, ISerializationCallbackReceiver
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

        
        private void OnEnable()
        {
            Debug.Log("BaseVariable::OnEnable: name is " + name);
            RuntimeInitialize();
            RaiseRuntimeInitializeEvent();
        }
        
        private void OnDisable()
        {
            Debug.Log("BaseVariable::OnDisable: name is " + name);
            RuntimeFinalize();
        }

        private void Reset()
        {
        }

        public virtual void RuntimeInitialize()
        {
            Debug.Log("BaseVariable::RuntimeInitialize: name is " + name);
            this.value = Clone(InitialValue);
        }

        public virtual void RaiseRuntimeInitializeEvent()
        {
            Debug.Log("BaseVariable::RaiseRuntimeInitializeEvent: name is " + name);
            OnPropertyChanged("Value");
        }

        public virtual void RuntimeFinalize()
        {
            Debug.Log("BaseVariable::RuntimeFinalize: name is " + name);
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