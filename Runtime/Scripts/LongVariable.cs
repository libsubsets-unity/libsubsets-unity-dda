using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/LongVariable")]
    public class LongVariable : BaseVariable<long>
    {
        protected override long Clone(long value)
        {
            return value;
        }
    }
}