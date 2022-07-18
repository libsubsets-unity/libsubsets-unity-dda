using UnityEngine;

namespace Subsets.Message2
{
    [CreateAssetMenu]
    public class StringEvent : GameEvent
    {
        public string Variable;
        
        public void Raise(string variable)
        {
            this.Variable = variable;
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }
    }
}