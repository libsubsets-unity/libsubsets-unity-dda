using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public abstract class BaseFsm: ScriptableObject
    {
        public abstract string GetState();
        public abstract bool IsInState(string state);

        public UnityEvent<string> StateChanged;
    }
}