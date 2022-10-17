using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu]
    public class FloatVariable : BaseVariable<float>
    {
        protected override float Clone(float value)
        {
            return value;
        }
    }
}