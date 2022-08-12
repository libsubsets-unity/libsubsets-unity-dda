using UnityEngine;

namespace Subsets.Message2
{
    [CreateAssetMenu]
    public class Vector2Event : GameEvent
    {
        public Vector2 Variable;
        
        public void Raise(Vector2 variable)
        {
            this.Variable = variable;
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }
    }
}