using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu(menuName = "Message2/Event/Long")]
    public class LongEvent : BaseEvent<long>
    {
        public void Raise(LongVariable variable)
        {
            Raise(variable.Value);
        }
    }
}