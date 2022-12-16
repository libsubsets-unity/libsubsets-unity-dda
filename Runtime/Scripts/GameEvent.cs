using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime 
{
    [Serializable]
    public struct Void
    {
        
    }
    
    [CreateAssetMenu(menuName = "Message2/Event/Game")]
    public class GameEvent : BaseEvent<Void>
    {
    }
}