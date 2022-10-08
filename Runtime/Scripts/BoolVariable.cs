using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class BoolVariable : BaseVariable<bool>
    {
        protected override bool Clone(bool value)
        {
            return value;
        }
    }
}