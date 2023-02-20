using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/IntegerVariable")]
    public class IntegerVariable : BaseVariable<int>
    {
        protected override int DuplicateValue(int value)
        {
            return value;
        }
    }
}