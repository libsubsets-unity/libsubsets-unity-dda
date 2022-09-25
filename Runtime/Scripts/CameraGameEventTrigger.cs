using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    public class CameraGameEventTrigger : MonoBehaviour
    {
        public Camera Camera;
        public UnityEvent OnScreenClick;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    Debug.Log("GameEventTrigger: hit name is " + objectHit.name);
                    if (OnScreenClick != null)
                    {
                        OnScreenClick.Invoke();
                    }
                }
            }

        }
    }
}