using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class StringVariable : BaseVariable, INotifyPropertyChanged
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public string Value
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
        private string _value;
                
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected override void Init()
        {
            PropertyChanged = null;
        }
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OnEnable()
        {
        }

        public void OnValidate()
        {
        }
    }
}