using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu]
    public class IntegerVariable : BaseVariable<int>
    {
        protected override int Clone(int value)
        {
            return value;
        }
    }
}