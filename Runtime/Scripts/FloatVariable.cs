using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class FloatVariable : BaseVariable, INotifyPropertyChanged
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value
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
        private float _value;
                        
        public event PropertyChangedEventHandler PropertyChanged;
                
        protected override void Init()
        {
            PropertyChanged = null;
        }
                
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        
        [SerializeField]
        public float InitValue;

        public void LoadInitValue()
        {
            Debug.Log("GameTestVariable::LoadInitValue");
            _value = InitValue;
        }
                
        public void OnBeforeSerialize()
        {
        }
                
        public void OnAfterDeserialize()
        {
            Debug.Log("GameTestVariable::OnAfterDeserialize");
            this.LoadInitValue();
        }
    }
}