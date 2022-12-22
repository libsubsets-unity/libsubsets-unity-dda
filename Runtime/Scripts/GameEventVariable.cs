using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Variable/GameEvent")]
    public class GameEventVariable : BaseVariable<GameEvent>
    {
        protected override GameEvent Clone(GameEvent value)
        {
            return value;
        }
    }
}