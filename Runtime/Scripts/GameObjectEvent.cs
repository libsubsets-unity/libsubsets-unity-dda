using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime 
{
    [CreateAssetMenu(menuName = "Message2/Event/GameObject")]
    public class GameObjectEvent : BaseEvent<GameObject>
    {
    }
}