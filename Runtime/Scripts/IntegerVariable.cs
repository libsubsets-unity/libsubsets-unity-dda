using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class IntegerVariable : BaseVariable<int>
    {
        protected override int Clone(int value)
        {
            return value;
        }
    }
}