using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class LongVariable : BaseVariable<long>
    {
        protected override long Clone(long value)
        {
            return value;
        }
    }
}