using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class IntegerVariable : BaseVariable, INotifyPropertyChanged
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value
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
        private int _value;
        public int InitValue;

        public event PropertyChangedEventHandler PropertyChanged;
                        
        protected override void Init()
        {
            PropertyChanged = null;
            Value = InitValue;
        }
                        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}