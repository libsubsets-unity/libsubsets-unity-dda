using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Dda 
{
    [Serializable]
    public struct Void
    {
        
    }
    
    [CreateAssetMenu(menuName = "Subsets.Dda/Event/GameEvent")]
    public class GameEvent : BaseEvent<Void>
    {
    }
}