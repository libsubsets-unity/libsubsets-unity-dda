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
    
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Event/Game")]
    public class GameEvent : BaseEvent<Void>
    {
    }
}