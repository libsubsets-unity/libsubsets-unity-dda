using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets.SoA/Variable/StringVariable")]
    public class StringVariable : BaseVariable<string>
    {
        protected override string Clone(string value)
        {
            return value;
        }
    }
}