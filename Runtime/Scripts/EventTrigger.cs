using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public class EventTrigger : MonoBehaviour
    {
        public string ViewEventName;
        public UnityEvent listener;
    }
}