using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Dda
{
    public class EventTrigger : MonoBehaviour
    {
        public string ViewEventName;
        public UnityEvent listener;
    }
}