using System;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    public class IntegerEventListener : GameEventListener
    {
        public int RaiseCondition = 0;
        public override void OnEventRaised()
        {
            IntegerEvent e = Event as IntegerEvent;
            if (e)
            {
                if (e.Variable == RaiseCondition)
                {
                    Response.Invoke();
                }
            }
        }
    }
}