using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Event/Long")]
    public class LongEvent : BaseEvent<long>
    {
        public void Raise(LongVariable variable)
        {
            Raise(variable.Value);
        }
    }
}