using UnityEngine;

namespace Subsets.Message2.Runtime
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