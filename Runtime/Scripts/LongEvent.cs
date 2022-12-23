using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets.SoA/Event/LongEvent")]
    public class LongEvent : BaseEvent<long>
    {
        public void Raise(LongVariable variable)
        {
            Raise(variable.Value);
        }
    }
}