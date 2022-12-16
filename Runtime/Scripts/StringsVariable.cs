using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu(menuName = "Message2/Variable/Strings")]
    public class StringsVariable : BaseVariable<List<string>>
    {
        protected override List<string> Clone(List<string> value)
        {
            return value.ToList();
        }
    }
}