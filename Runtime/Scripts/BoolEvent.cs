using UnityEngine;

namespace Subsets.Message2
{
    [CreateAssetMenu]
    public class BoolEvent : GameEvent
    {
        public bool Variable;
        
        public void Raise(bool variable)
        {
            this.Variable = variable;
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }
    }
}