using System;
using System.ComponentModel;
using PlayGem.JawRed.Core.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public abstract class BaseStateMachine: ScriptableObject, INotifyPropertyChanged
    {
        public StringVariable State;
        public StringVariable OldState;
        public StringVariable SuperState;
        public abstract event PropertyChangedEventHandler PropertyChanged;
        public abstract bool IsInState(string state);
    }
}