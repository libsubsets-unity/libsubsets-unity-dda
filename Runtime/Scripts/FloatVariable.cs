using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
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