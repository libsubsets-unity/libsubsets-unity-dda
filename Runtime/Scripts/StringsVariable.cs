using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/String(s)Variable")]
    public class StringsVariable : BaseVariable<List<string>>
    {
        protected override List<string> Clone(List<string> value)
        {
            return value.ToList();
        }
    }
}