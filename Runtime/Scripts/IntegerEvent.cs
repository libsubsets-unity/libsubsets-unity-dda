using PlayGem.JawRed.Core.Variables;
using UnityEngine;

namespace Subsets.Message2
{
    [CreateAssetMenu]
    public class IntegerEvent : BaseEvent<int>
    {
        public void Raise(IntegerVariable variable)
        {
            Raise(variable.Value);
        }
    }
}