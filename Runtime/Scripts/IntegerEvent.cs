using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Event/Integer")]
    public class IntegerEvent : BaseEvent<int>
    {
        public void Raise(IntegerVariable variable)
        {
            Raise(variable.Value);
        }
    }
}