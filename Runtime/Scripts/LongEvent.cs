using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Event/LongEvent")]
    public class LongEvent : BaseEvent<long>
    {
        public void Raise(LongVariable variable)
        {
            Raise(variable.Value);
        }
    }
}