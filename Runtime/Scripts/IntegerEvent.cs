using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets.SoA/Event/IntegerEvent")]
    public class IntegerEvent : BaseEvent<int>
    {
        public void Raise(IntegerVariable variable)
        {
            Raise(variable.Value);
        }
    }
}