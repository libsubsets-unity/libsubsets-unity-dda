using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu]
    public class BoolMapVariable : BaseMapVariable<BoolVariable>
    {
        protected override Dictionary<string, BoolVariable> Clone(Dictionary<string, BoolVariable> value)
        {
            return new Dictionary<string, BoolVariable>(value);
        }
    }
}