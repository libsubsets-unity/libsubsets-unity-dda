using System;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    public abstract class BaseVariable<T> : ScriptableObject, INotifyPropertyChanged, IRuntimeInitialize, IRuntimeFinalization
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
                this.OldValue = Clone(this.Value);
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

        public void RuntimeInitialize()
        {
            this.value = Clone(InitialValue);
        }

        public void RaiseRuntimeInitializeEvent()
        {
            OnPropertyChanged("Value");
        }

        public void RuntimeFinalize()
        {
            PropertyChanged = null;
        }

        protected abstract T Clone(T value);
        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}