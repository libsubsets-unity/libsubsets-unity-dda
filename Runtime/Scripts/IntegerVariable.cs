using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Variable/Integer")]
    public class IntegerVariable : BaseVariable<int>
    {
        protected override int Clone(int value)
        {
            return value;
        }
    }
}