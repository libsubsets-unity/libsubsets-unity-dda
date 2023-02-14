using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/FloatVariable")]
    public class FloatVariable : BaseVariable<float>
    {
        protected override float Clone(float value)
        {
            return value;
        }
    }
}