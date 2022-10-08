using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class StringVariable : BaseVariable<string>
    {
        protected override string Clone(string value)
        {
            return value;
        }
    }
}