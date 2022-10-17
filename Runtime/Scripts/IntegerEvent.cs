using UnityEngine;

namespace Subsets.Message2.Runtime
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