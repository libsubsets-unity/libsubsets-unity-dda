using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/StringVariable")]
    public class StringVariable : BaseVariable<string>
    {
        protected override string DuplicateValue(string value)
        {
            return value;
        }
    }
}