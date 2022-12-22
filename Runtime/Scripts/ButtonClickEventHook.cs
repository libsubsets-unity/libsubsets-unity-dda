using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LibSubsets.SoA
{
    public class ButtonClickEventHook : MonoBehaviour
    {
        public UnityEvent Event;
        
        public void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClickEvent);
        }

        public void Raise()
        {
            var button = GetComponent<Button>();
            button.onClick.RemoveListener(OnClickEvent);
        }

        private void OnClickEvent()
        {
            Event?.Invoke();
        }
    }
}