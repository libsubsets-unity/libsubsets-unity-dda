using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Event/IntegerEvent")]
    public class IntegerEvent : BaseEvent<int>
    {
        public void Raise(IntegerVariable variable)
        {
            Raise(variable.Value);
        }
    }
}