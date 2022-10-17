using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
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