using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu]
    public class GameEventVariable : BaseVariable<GameEvent>
    {
        protected override GameEvent Clone(GameEvent value)
        {
            return value;
        }
    }
}