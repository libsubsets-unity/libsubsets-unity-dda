using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu(menuName = "Message2/Variable/String")]
    public class StringVariable : BaseVariable<string>
    {
        protected override string Clone(string value)
        {
            return value;
        }
    }
}