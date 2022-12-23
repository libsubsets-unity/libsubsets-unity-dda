using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA 
{
    [CreateAssetMenu(menuName = "LibSubsets.SoA/Event/GameObjectEvent")]
    public class GameObjectEvent : BaseEvent<GameObject>
    {
    }
}