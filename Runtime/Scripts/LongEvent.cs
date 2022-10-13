using PlayGem.JawRed.Core.Variables;
using UnityEngine;

namespace Subsets.Message2
{
    [CreateAssetMenu]
    public class LongEvent : BaseEvent<long>
    {
        public void Raise(LongVariable variable)
        {
            Raise(variable.Value);
        }
    }
}