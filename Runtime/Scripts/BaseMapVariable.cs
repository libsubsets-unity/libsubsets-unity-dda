using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Subsets.Message2;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
{
    public abstract class BaseMapVariable<T> : ScriptableObject, ISerializationCallbackReceiver, INotifyPropertyChanged, IRuntimeInitialize
    {
        [Multiline]
        public string DeveloperDescription = "";

        public Dictionary<string, T> Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.OldValue = Clone(this.Value);
                this.Value = value;
                OnPropertyChanged("Value");
            }
        }

        public Dictionary<string, T> InitialValue;
        public Dictionary<string, T> OldValue;
        public event PropertyChangedEventHandler PropertyChanged;

        [SerializeField] private Dictionary<string, T> value;

        public void Reset()
        {
            Initialize();
        }

        protected void Initialize()
        {
            PropertyChanged = null;
            Value = Clone(InitialValue);
        }

        protected abstract Dictionary<string, T> Clone(Dictionary<string, T> value);
        
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