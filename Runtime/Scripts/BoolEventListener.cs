using System;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    public class BoolEventListener : GameEventListener
    {
        public bool RaiseCondition = false;
        public override void OnEventRaised()
        {
            BoolEvent e = Event as BoolEvent;
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