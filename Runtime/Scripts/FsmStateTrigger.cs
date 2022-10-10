using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DefaultNamespace;
using PlayGem.JawRed.Core.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public class FsmStateTrigger : MonoBehaviour
    {
        public enum StateCompare
        {
            Equal,
            Contains,
            IsInState,
            IsNot
        }
        [Serializable]
        public class StateCondition
        {
            [SerializeField]
            public BaseStateMachine StateMachine;
            public StateCompare Compare;
            public string Value;
        }

        public bool Enabled = false;
        public ResponseConditionOperator ConditionOperator;
        [NonReorderable] public List<StateCondition> Conditions = new List<StateCondition>();
        public UnityEvent Listeners;
        
        public void Awake()
        {
            if (Enabled)
            {
                foreach (StateCondition condition in Conditions)
                {
                    condition.StateMachine.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
                    {
                        Execute();
                    };
                }
            }
        }

        private void Execute()
        {
            ConditionCompareResult result = new ConditionCompareResult();
            foreach (StateCondition condition in Conditions)
            {
                if (condition.Compare == StateCompare.Equal)
                {
                    result.Add(condition.StateMachine.State.Value.Equals(condition.Value));
                }
                else if (condition.Compare == StateCompare.Contains)
                {
                    result.Add(condition.StateMachine.State.Value.Contains(condition.Value));
                }
                else if (condition.Compare == StateCompare.IsNot)
                {
                    result.Add(!condition.StateMachine.State.Value.Equals(condition.Value));
                }    
                else if (condition.Compare == StateCompare.IsInState)
                {
                    result.Add(condition.StateMachine.IsInState(condition.Value));
                }
            }
            if (result.CheckConditionOperator(ConditionOperator))
            {
                Listeners?.Invoke();
            }
        }
    }
}