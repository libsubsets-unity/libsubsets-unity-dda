using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets.SoA/Variable/LongVariable")]
    public class LongVariable : BaseVariable<long>
    {
        protected override long Clone(long value)
        {
            return value;
        }
    }
}