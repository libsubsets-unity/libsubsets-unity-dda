using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    [Serializable]
    public abstract class BaseCondition<TVariable, TType> where TVariable : BaseVariable<TType>
    {
        public TVariable Target;
    }
    
    public abstract class BaseTrigger<TCondition, TVariable, TType>: MonoBehaviour 
        where TVariable : BaseVariable<TType>
        where TCondition : BaseCondition<TVariable, TType>
    {
        public List<TCondition> Conditions;
        public UnityEvent Listeners;
        
        public bool StopTriggerWhenEnter;
        
        public bool ExecuteWhenStarted = false;
        public bool ExecutePeriodic = false;
        public float ExecutePeriodicTime = 1.0f;

        private float time;
        public void Start()
        {
            foreach (TCondition condition in Conditions)
            {
                condition.Target.PropertyChanged += OnChanged;
            }
            if (ExecuteWhenStarted)
            {
                Execute();
            }
        }
        private void OnDestroy()
        {
            foreach (BaseCondition<TVariable, TType> condition in Conditions)
            {
                condition.Target.PropertyChanged -= OnChanged;
            }
        }
        
        private void Update()
        {
            if (ExecutePeriodic)
            {
                time += Time.deltaTime;
                if (time > ExecutePeriodicTime)
                {
                    time = time - ExecutePeriodicTime;
                    Execute();
                }
            }
        }

        private void TriggerEnter()
        {
            Listeners.Invoke();
            if (StopTriggerWhenEnter)
            {
                enabled = false;
            }
        }

        void OnChanged(object sender, PropertyChangedEventArgs args)
        {
            Execute(); 
        }

        void Execute()
        {
            if (MatchCondition())
            {
                TriggerEnter();
            }
        }

        protected abstract bool MatchCondition();
    }
}