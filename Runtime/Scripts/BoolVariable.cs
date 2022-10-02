using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class BoolVariable : BaseVariable, INotifyPropertyChanged
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public bool Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
            
        }

        [SerializeField]
        private bool _value;
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void Init()
        {
            PropertyChanged = null;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}