using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
{
    public class EventTrigger : MonoBehaviour
    {
        public string ViewEventName;
        public UnityEvent listener;
    }
}