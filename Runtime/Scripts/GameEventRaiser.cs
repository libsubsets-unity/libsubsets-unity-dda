using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public class GameEventRaiser : MonoBehaviour
    {
        public UnityEvent Listeners;

        public void Raise()
        {
            if (Listeners != null)
            {
                Listeners.Invoke();
            }
        }
    }
}