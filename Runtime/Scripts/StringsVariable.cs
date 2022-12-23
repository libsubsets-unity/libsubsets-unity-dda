using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets.SoA/Variable/String(s)Variable")]
    public class StringsVariable : BaseVariable<List<string>>
    {
        protected override List<string> Clone(List<string> value)
        {
            return value.ToList();
        }
    }
}