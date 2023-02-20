using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/GameEventVariable")]
    public class GameEventVariable : BaseVariable<GameEvent>
    {
        protected override GameEvent DuplicateValue(GameEvent value)
        {
            return value;
        }
    }
}