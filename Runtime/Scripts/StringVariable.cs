using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Variable/String")]
    public class StringVariable : BaseVariable<string>
    {
        protected override string Clone(string value)
        {
            return value;
        }
    }
}