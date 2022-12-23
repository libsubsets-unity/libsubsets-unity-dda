using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA 
{
    [Serializable]
    public struct Void
    {
        
    }
    
    [CreateAssetMenu(menuName = "LibSubsets.SoA/Event/GameEvent")]
    public class GameEvent : BaseEvent<Void>
    {
    }
}