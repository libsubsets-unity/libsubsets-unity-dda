using UnityEngine;

namespace Subsets.Message2
{
    [CreateAssetMenu]
    public class IntegerEvent : GameEvent
    {
        public int Variable;
        
        public void Raise(int variable)
        {
            this.Variable = variable;
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }
    }
}