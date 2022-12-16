using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu(menuName = "Message2/Event/Integer")]
    public class IntegerEvent : BaseEvent<int>
    {
        public void Raise(IntegerVariable variable)
        {
            Raise(variable.Value);
        }
    }
}