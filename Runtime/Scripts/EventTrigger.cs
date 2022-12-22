using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    public class EventTrigger : MonoBehaviour
    {
        public string ViewEventName;
        public UnityEvent listener;
    }
}