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
            public BaseFsm BaseFsm;
            public StateCompare Compare;
            public string Value;
        }
        
        public ResponseConditionOperator ConditionOperator;
        [NonReorderable] public List<StateCondition> Conditions = new List<StateCondition>();
        public UnityEvent Listeners;
        
        public void Awake()
        {
            foreach (StateCondition condition in Conditions)
            {
                condition.BaseFsm.StateChanged.AddListener(delegate(string arg0)
                {
                    Execute();
                });
            }
        }

        private void Execute()
        {
            ConditionCompareResult result = new ConditionCompareResult();
            foreach (StateCondition condition in Conditions)
            {
                if (condition.Compare == StateCompare.Equal)
                {
                    result.Add(condition.BaseFsm.GetState().Equals(condition.Value));
                }
                else if (condition.Compare == StateCompare.Contains)
                {
                    result.Add(condition.BaseFsm.GetState().Contains(condition.Value));
                }
                else if (condition.Compare == StateCompare.IsNot)
                {
                    result.Add(!condition.BaseFsm.GetState().Equals(condition.Value));
                }    
                else if (condition.Compare == StateCompare.IsInState)
                {
                    result.Add(condition.BaseFsm.IsInState(condition.Value));
                }
            }
            if (result.CheckConditionOperator(ConditionOperator))
            {
                Listeners?.Invoke();
            }
        }
    }
}