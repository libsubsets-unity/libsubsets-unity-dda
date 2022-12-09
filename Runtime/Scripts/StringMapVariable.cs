using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu]
    public class StringMapVariable : BaseMapVariable<StringVariable>
    {
        protected override Dictionary<string, StringVariable> Clone(Dictionary<string, StringVariable> value)
        {
            return new Dictionary<string, StringVariable>(value);
        }
    }
}