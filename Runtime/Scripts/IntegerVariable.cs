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
        public int Value;

        [SerializeField]
        private float _value;

        new public void OnAfterDeserialize()
        {
            _value = Value;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
                        
        protected override void Init()
        {
            PropertyChanged = null;
        }
                        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
                
        /*
        [SerializeField]
        public float InitValue;
        
        public void LoadInitValue()
        {
            Debug.Log("FloatVariable::LoadInitValue");
            _value = InitValue;
        }
                        
        public void OnBeforeSerialize()
        {
        }
        
        public void OnAfterDeserialize()
        {
            Debug.Log("FloatVariable::OnAfterDeserialize");
            this.LoadInitValue();
        }
        */
    }
}