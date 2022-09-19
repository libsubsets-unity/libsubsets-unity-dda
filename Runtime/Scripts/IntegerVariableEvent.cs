using NPOI.POIFS.Properties;
using PlayGem.JawRed.Core.Variables;
using UnityEngine;

namespace Subsets.Message2
{
    [CreateAssetMenu]
    public class IntegerVariableEvent : GameEvent
    {
        public IntegerVariable Variable;
        
        public void Raise(IntegerVariable variable)
        {
            this.Variable = variable;
            this.Raise();
        }
    }
}